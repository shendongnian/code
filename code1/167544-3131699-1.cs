       public class NullableFKConvention : IReferenceConvention
       {
           public void Apply(IManyToOneInstance instance)
           {
               instance.Nullable();
           }
       }
