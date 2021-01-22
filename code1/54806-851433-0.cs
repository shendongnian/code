            using (NamedPipeServerStream input = new NamedPipeServerStream("Test", PipeDirection.InOut))
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream("Test"))
            using (MemoryStream output = new MemoryStream())
            using (StreamReader inSerial = new StreamReader(pipeClient))
            using (StreamWriter outSerial = new StreamWriter(svpConsumer))
            {
                StartPipeServer(input);
                pipeClient.Connect();
                using (TestingClass myTest = new TestingClass(onSerial, outSerial))
                {
                   input.Write(...);
                   input.Flush(...);
                   Assert on checking output
                }
            }
