    public partial class SomeEntity
    {
         public static SomeEntity Create()
         {
             return new SomeEntity() { Id = Guid.NewGuid(); }
         }
    }
