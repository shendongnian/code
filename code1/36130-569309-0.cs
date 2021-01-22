        [Serializable]
        public class LocalizableDescriptionAttribute:DescriptionAttribute
        {
            public LocalizableDescriptionAttribute(string resourceKey)
                :base(Resources.ResourceManager.GetString(resourceKey))
            { }
    
        }
