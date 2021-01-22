    [AttributeUsage(AttributeTargets.All)]
    internal sealed class SRDescriptionAttribute : DescriptionAttribute
    {
        private bool replaced;
    
        public SRDescriptionAttribute(string description) : base(description)
        {
        }
    
        public override string Description
        {
            get
            {
                if (!this.replaced)
                {
                    this.replaced = true;
                    base.DescriptionValue = SR.GetString(base.Description);
                }
                return base.Description;
            }
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class SRCategoryAttribute : CategoryAttribute
    {
        public SRCategoryAttribute(string category) : base(category)
        {
        }
    
        protected override string GetLocalizedString(string value)
        {
            return SR.GetString(value);
        }
    }
