        private Dictionary<Type, Type> Diccionary;
        public void CreateDicionary()
        {
            Diccionary = new Dictionary<Type, Type>();
            Diccionary.Add(typeof(AGeneratorConfig), typeof(AGenerator));
            Diccionary.Add(typeof(BGeneratorConfig), typeof(BGenerator));
        }
