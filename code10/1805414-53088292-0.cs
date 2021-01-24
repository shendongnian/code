    public class CheckRequestModelConfiguration : IModelConfiguration
    {
       public void Apply(
          ODataModelBuilder builder,
          ApiVersion apiVersion)
       {
          switch (apiVersion.MajorVersion)
          {
             default:
                ConfigureV1(builder);
                break;
          }
       }
    
       private static void ConfigureV1(ODataModelBuilder builder)
       {
          builder.AddFunction("checkrequests").Returns<CheckResult>();
       }
    }
