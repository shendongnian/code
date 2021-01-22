        [WebBrowsable(true),
        Resources("SearchWebPartWebDisplayName", 
        "SearchWebPartCategory", 
        "SearchWebPartWebDescription"),
        FriendlyName("Display Name here"),
        Description("Tells you all about it"),
        Category("My Category"),
        Personalizable(PersonalizationScope.Shared)]
        public string SomeProperty { get; set; }
    
        public override string LoadResource(string id)
        {
            string result = Properties.Resources.ResourceManager.GetString(id);
            return result;
        }
