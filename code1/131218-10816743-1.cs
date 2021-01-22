    class ViewModelBuilderFactory
    {
        private Dictionary<string, System.Type> resolver;
        public void ViewModelBuilderFactory()
        {
            resolver = new Dictionary<string, Type>
            {
                {"ProgressNotes", typeof(ProgressNotesViewModelBuilder)},
                {"Labs", typeof(LabsViewModelBuilder)}
            };
        }
        public IViewModelBuilder GetViewModelBuilder(string key)
        {
            System.Type type = this.resolver[key];
            return (IViewModelBuilder)Activator.CreateInstance(type);
        }
    }
