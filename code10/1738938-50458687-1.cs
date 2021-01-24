    interface IApplication
    {
        Application Application { get; }
    }
    class ApplicationWrapper : IApplication
    {
        protected readonly Application _application;
        public ApplicationWrapper()
        {
            _application = Application.GetInstance();
        }
        public Application Application
        {
            get { return _application; }
        }
    }
