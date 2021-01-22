    public class BasicLabelConfiguration
    {
      public BasicLabelConfiguration()
      {
      }
      public string TrackingReference { get; set; }
    }
    public class CustomLabelConfiguration : BasicLabelConfiguration
    {
      public CustomLabelConfiguration()
      {
      }
      public string CustomText { get; set; }
    }
 
    public class LabelFactory
    {
      public ILabel CreateLabel(BasicLabelConfiguration configuration)
      {
        // Possibly make decision from configuration
        CustomLabelConfiguration clc = configuration as CustomLabelConfiguration;
        if (clc != null)
        {
          return new CustomLabel(clc.TrackingReference, clc.CustomText);
        }
        else
        {
          return new BasicLabel(configuration.TrackingReference);
        }
      }
    }
