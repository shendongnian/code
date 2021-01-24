      public void StartPipe()
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                RecursivePipe();
            });
        }
        public void RecursivePipe()
        {
            PipeSecurity pipeSecurity = new PipeSecurity();
            pipeSecurity.AddAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null), PipeAccessRights.ReadWrite | PipeAccessRights.CreateNewInstance, AccessControlType.Allow));
            pipeSecurity.AddAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null), PipeAccessRights.FullControl, AccessControlType.Allow));
            var server = new NamedPipeServerStream("PipeService7", PipeDirection.InOut, 10, PipeTransmissionMode.Message, PipeOptions.WriteThrough, 1024, 1024, pipeSecurity);
            
            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var lineArray = line.Split('$');
                if (lineArray.Length == 4)
                {
                    SetkeyValue(lineArray);
                }
                else if (lineArray.Length == 5)
                {
                    setStartupStrat(lineArray);
                }
                else
                {
                    DeleteKeyValue(lineArray);
                }
            }
            server.Dispose();
            server.Close();
            RecursivePipe();
        }
