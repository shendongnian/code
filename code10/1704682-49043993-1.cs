    class ViewModelLocator
    {
        public SchoolViewModel SchoolViewModel
        {
            get { return Bootstrap.Container.Resolve<SchoolViewModel>(); } 
        }
    }
