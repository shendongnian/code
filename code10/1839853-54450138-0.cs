    public sealed partial class BlankPage1 : Page
    {
        private GazeElement gazeButtonControl;
        private GazePointer gazePointer;
        static Dictionary<object, Stopwatch> stopwatchesByObject;
        public BlankPage1()
        {
            this.InitializeComponent();
            gazePointer = GazeInput.GetGazePointer(null);
            gazeButtonControl = GazeInput.GetGazeElement(GazeBlock);
            gazeButtonControl = new GazeElement();
            GazeInput.SetGazeElement(GazeBlock, gazeButtonControl);
            gazeButtonControl.StateChanged += GazeButtonControl_StateChanged;
            // Add the object to our dictionary along with a new stopwatch
            stopwatchesByObject.Add(gazeButtonControl, new Stopwatch());
            private void GazeButtonControl_StateChanged(object sender, StateChangedEventArgs ea)
            {
                // Use the sender argument to choose the correct timer
                if (ea.PointerState == PointerState.Enter)
                {
                    if (stopwatchesByObject.ContainsKey(sender))
                    {
                        stopwatchesByObject[sender].Start();
                    }
                }
                else if (ea.PointerState == PointerState.Exit)
                {
                    if (stopwatchesByObject.ContainsKey(sender))
                    {
                        stopwatchesByObject[sender].Stop();
                        CreateStatistics();
                    }
                }
            }
            private void CreateStatistics()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var entry in stopwatchesByObject)
                {
                    sb.AppendLine($"Gazed at {entry.Key} for {entry.Value.Elapsed.TotalSeconds} seconds.");
                }
                File.WriteAllText("c:\\temp\\statictics.txt", sb.ToString());
            }
        }
    }
