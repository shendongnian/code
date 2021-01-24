    {
    	"method": "Runtime.evaluate",
    	"params": {
    		"expression": "document.location='urlhere'",
    		"objectGroup": "console",
    		"includeCommandLineAPI": true,
    		"doNotPauseOnExceptions": false,
    		"returnByValue": false
    	},
    	"id": 1
    }
    public dynamic SendCommand(string cmd)
            {
                if (EventHandler == null)
                {
                    EventHandler = new Events();
                    EventHandler.OnNavigateStart += new Events.OnPageNavigateStart(EventHandler_OnNavigateStart);
                    EventHandler.OnNavigateEnd += new Events.OnPageNavigateEnded(EventHandler_OnNavigateEnd);
                }
                WebSocket4Net.WebSocket j = new WebSocket4Net.WebSocket(this.sessionWSEndpoint);
                ManualResetEvent waitEvent = new ManualResetEvent(false);
                ManualResetEvent closedEvent = new ManualResetEvent(false);
                dynamic message = null;
                byte[] data;
    
                Exception exc = null;
                j.Opened += delegate(System.Object o, EventArgs e)
                {
                    j.Send(cmd);
                };
    
                j.MessageReceived += delegate(System.Object o, WebSocket4Net.MessageReceivedEventArgs e)
                {
                    message = e.Message;
                    EventHandler.ParseEvents(e);
                    waitEvent.Set();
                    
                };
    
                j.Error += delegate(System.Object o, SuperSocket.ClientEngine.ErrorEventArgs e)
                {
                    exc = e.Exception;
                    waitEvent.Set();
                };
    
                j.Closed += delegate(System.Object o, EventArgs e)
                {
                    closedEvent.Set();
                };
    
                j.DataReceived += delegate(object sender, WebSocket4Net.DataReceivedEventArgs e)
                {
                    data = e.Data;
                    waitEvent.Set();
                };
    
                j.Open();
    
                waitEvent.WaitOne();
                if (j.State == WebSocket4Net.WebSocketState.Open)
                {
                    j.Close();
                    closedEvent.WaitOne();
                    j = null;
                }
                
                if (exc != null)
                    throw exc;
                serializer = null;
                serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new[] { converter });
    
                dynamic obj = serializer.Deserialize(message, typeof(object));
                message = null;
                data = null;
                return obj;
            }
