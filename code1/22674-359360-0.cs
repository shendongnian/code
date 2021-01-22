       [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event)]
       public class DisplayNameLocalizedAttribute : DisplayNameAttribute
       {
          public DisplayNameLocalizedAttribute(Type resourceManagerProvider, string resourceKey)
             : base(Utils.LookupResource(resourceManagerProvider, resourceKey))
          {
          }
       }
