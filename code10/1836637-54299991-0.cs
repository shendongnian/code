    namespace ClassLessons
    {
        class AtCommand
        {
            Uart GsmPort = new Uart();
            public AtCommand()
            {
                GsmPort.Write("Test");
            }
        }
    }
