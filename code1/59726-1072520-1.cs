    namespace TestWebservice
    {
       public class MyReflector : SoapExtensionReflector
       {
          public override void ReflectMethod()
          {
             //no-op
          }
          public override void ReflectDescription()
          {
             ServiceDescription description = ReflectionContext.ServiceDescription;
             if (description.PortTypes[0].Operations.Count == 2)
                description.PortTypes[0].Operations.RemoveAt(0);
             if (description.Messages.Count == 4)
             {
                description.Messages.RemoveAt(0);
                description.Messages.RemoveAt(0);
             }
             foreach (Binding binding in description.Bindings)
             {
                if (binding.Operations.Count == 2)
                   binding.Operations.RemoveAt(0);
             }
             if (description.Types.Schemas[0].Items.Count == 4)
             {
                description.Types.Schemas[0].Items.RemoveAt(0);
                description.Types.Schemas[0].Items.RemoveAt(0);
             }
          }
       }
    }
