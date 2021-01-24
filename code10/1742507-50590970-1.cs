    class AssemblyLoader : MarshalByRefObject
    {
        private DomainHost host;
        public void Initialize(DomainHost host)
        {
            // store the remote host here so you will able to use it to send feedbacks
            this.host = host;
            host.SendData("I am just being initialized.")
        }
        // of course, if your job has some final result you can have a return value
        // and then you don't even may need the DomainHost.
        // But do not return any Type from the loaded dll (not mentioning the whole Assembly).
        public void DoWork()
        {
            host.SendData("Work started. Now I will load some dll.");
            // TODO: load and use dll
            host.SendData(42);
            
            host.SendData("Job finished.")
        }
    }
