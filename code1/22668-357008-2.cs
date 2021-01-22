    class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private readonly string resourceName;
        public LocalizedDisplayNameAttribute(string resourceName)
            : base()
        {
          this.resourceName = resourceName;
        }
        public override string DisplayName
        {
            get
            {
                return Resources.ResourceManager.GetString(this.resourceName);
            }
        }
    }
