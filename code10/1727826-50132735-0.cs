    /// <summary>
    /// class to create a gstreamer pipeline based on an rtsp stream at the provided URL
    /// </summary>
    class gstPipeline2
    {
        // elements for the pipeline
        private Element uriDecodeBin, videoSink;
        private System.Threading.Thread mainGLibThread;
        private GLib.MainLoop mainLoop;
        // the window handle (passed in)
        private IntPtr windowHandle;
        // our pipeline
        private Pipeline currentPipeline = null;
        /// <summary>
        /// Create a new gstreamer pipeline rendering the stream at URL into the provided window handle 
        /// </summary>
        /// <param name="WindowHandle">The handle of the window to render to </param>
        /// <param name="Url">The url of the video stream</param>
        public gstPipeline2(string Url, IntPtr WindowHandle)
        {
            windowHandle = WindowHandle;    // get the handle and save it locally
            // initialise the gstreamer library and associated threads (for diagnostics)
            Gst.Application.Init();
            mainLoop = new GLib.MainLoop();
            mainGLibThread = new System.Threading.Thread(mainLoop.Run);
            mainGLibThread.Start();
            // create each element now for the pipeline
            uriDecodeBin = ElementFactory.Make("uridecodebin", "uriDecodeBin0");  // create an uridecodebin (which handles most of the work for us!!)
            uriDecodeBin["uri"] = Url;   // and set its location (the source of the data)
            videoSink = ElementFactory.Make("autovideosink", "sink0");  // and finally the sink to render the video (redirected to the required window handle below in Bus_SyncMessage() ) 
            // create our pipeline which links all the elements together into a valid data flow
            currentPipeline = new Pipeline("pipeline");
            currentPipeline.Add(uriDecodeBin, videoSink); // add the required elements into it
            uriDecodeBin.PadAdded += uriDecodeBin_PadAdded; // subscribe to the PadAdded event so we can link new pads (sources of data?) to the depayloader when they arrive
            uriDecodeBin.Connect("source-setup", SourceSetup);  // subscribe to the "source-setup" signal, not quite done in the usual C# eventing way but treat it as essentially the same
            // subscribe to the messaging system of the bus and pipeline so we can monitor status as we go
            Bus bus = currentPipeline.Bus;
            bus.AddSignalWatch();
            bus.Message += Bus_Message;
            bus.EnableSyncMessageEmission();
            bus.SyncMessage += Bus_SyncMessage;
            // finally set the state of the pipeline running so we can get data
            var setStateReturn = currentPipeline.SetState(State.Null);
            System.Diagnostics.Debug.WriteLine("SetStateNULL returned: " + setStateReturn.ToString());
            setStateReturn = currentPipeline.SetState(State.Ready);
            System.Diagnostics.Debug.WriteLine("SetStateReady returned: " + setStateReturn.ToString());
            setStateReturn = currentPipeline.SetState(State.Playing);
            System.Diagnostics.Debug.WriteLine("SetStatePlaying returned: " + setStateReturn.ToString());
        }
        private void uriDecodeBin_PadAdded(object o, PadAddedArgs args)
        {
            System.Diagnostics.Debug.WriteLine("uriDecodeBin_PadAdded: called with new pad named: " + args.NewPad.Name);
            
            // a pad has been added to the source so we need to link it to the rest of the pipeline to ultimately display it onscreen
            Pad sinkPad = videoSink.GetStaticPad("sink");   // get the pad for the one we have recieved  so we can link to the depayloader element
            System.Diagnostics.Debug.WriteLine("uriDecodeBin_PadAdded: queue pad returned: " + sinkPad.Name);
            PadLinkReturn ret = args.NewPad.Link(sinkPad);
            
            System.Diagnostics.Debug.WriteLine("uriDecodeBin_PadAdded: link attempt returned: " + ret.ToString());
        }
        void SourceSetup(object sender, GLib.SignalArgs args)
        {
            // we need to delve into the source portion of the uridecodebin to modify the "latency" property, need to add some validation here to ensure this is an rtspsrc
            var source = (Element)args.Args[0];
            System.Diagnostics.Debug.WriteLine("SourceSetup: source is named: " + source.Name + ", and is of type: " + source.NativeType.ToString());
            source["latency"] = 0;  // this COULD throw an exception if the source is not rtspsrc or similar with a "latency" property
        }
        public void killProcess()
        {
            mainLoop.Quit();
        }
        private void Bus_SyncMessage(object o, SyncMessageArgs args)
        {
            if (Gst.Video.Global.IsVideoOverlayPrepareWindowHandleMessage(args.Message))
            {
                System.Diagnostics.Debug.WriteLine("Bus_SyncMessage: Message prepare window handle received by: " + args.Message.Src.Name + " " + args.Message.Src.GetType().ToString());
                if (args.Message.Src != null)
                {
                    // these checks were in the testvideosrc example and failed, args.Message.Src is always Gst.Element???
                    if (args.Message.Src is Gst.Video.VideoSink)
                        System.Diagnostics.Debug.WriteLine("Bus_SyncMessage: source is VideoSink");
                    else
                        System.Diagnostics.Debug.WriteLine("Bus_SyncMessage: source is NOT VideoSink");
                    if (args.Message.Src is Gst.Bin)
                        System.Diagnostics.Debug.WriteLine("Bus_SyncMessage: source is Bin");
                    else
                        System.Diagnostics.Debug.WriteLine("Bus_SyncMessage: source is NOT Bin");
                    try
                    {
                        args.Message.Src["force-aspect-ratio"] = true;
                    }
                    catch (PropertyNotFoundException) { }
                    try
                    {
                        Gst.Video.VideoOverlayAdapter adapter = new VideoOverlayAdapter(args.Message.Src.Handle);
                        adapter.WindowHandle = windowHandle;
                        adapter.HandleEvents(true);
                        System.Diagnostics.Debug.WriteLine("Bus_SyncMessage: Handle passed to adapter: " + windowHandle.ToString());
                    }
                    catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Bus_SyncMessage: Exception Thrown (overlay stage): " + ex.Message); }
                }
            }
            else
            {
                string info;
                IntPtr prt;
                args.Message.ParseInfo(out prt, out info);
                System.Diagnostics.Debug.WriteLine("Bus_SyncMessage: " + args.Message.Type.ToString() + " - " + info);
            }
        }
        private void Bus_Message(object o, MessageArgs args)
        {
            var msg = args.Message;
            //System.Diagnostics.Debug.WriteLine("HandleMessage received msg of type: {0}", msg.Type);
            switch (msg.Type)
            {
                case MessageType.Error:
                    //
                    GLib.GException err;
                    string debug;
                    System.Diagnostics.Debug.WriteLine("Bus_Message: Error received: " + msg.ToString());
                    break;
                case MessageType.StreamStatus:
                    Gst.StreamStatusType status;
                    Element theOwner;
                    msg.ParseStreamStatus(out status, out theOwner);
                    System.Diagnostics.Debug.WriteLine("Bus_Message: Case SteamingStatus: status is: " + status + " ; Owner is: " + theOwner.Name);
                    break;
                case MessageType.StateChanged:
                    State oldState, newState, pendingState;
                    msg.ParseStateChanged(out oldState, out newState, out pendingState);
                    if (newState == State.Paused)
                        args.RetVal = false;
                    System.Diagnostics.Debug.WriteLine("Bus_Message: Pipeline state changed from {0} to {1}: ; Pending: {2}", Element.StateGetName(oldState), Element.StateGetName(newState), Element.StateGetName(pendingState));
                    break;
                case MessageType.Element:
                    System.Diagnostics.Debug.WriteLine("Bus_Message: Element message: {0}", args.Message.ToString());
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Bus_Message: HandleMessage received msg of type: {0}", msg.Type);
                    break;
            }
            args.RetVal = true;
        }
    }
