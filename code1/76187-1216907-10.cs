        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new CustomMessageInspector());
            clientRuntime.MessageInspectors.Add(new DebugMessageInspector());
        }
