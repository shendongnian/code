    using System.ComponentModel.DataAnnotations;
    using Resources;
    namespace Web.Extensions.ValidationAttributes
    {
        public static class ValidationAttributeHelper
        {
            public static ValidationContext LocalizeDisplayName(this ValidationContext    context)
            {
                context.DisplayName = Labels.ResourceManager.GetString(context.DisplayName) ?? context.DisplayName;
                return context;
            }
        }
    }
