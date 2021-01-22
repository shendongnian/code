    public class MyModelValidator : FluentValidator<MyModel>
    {
      public MyModelValidator()
      {
        Property("FirstName").Required();
        Property("LastName").Required().Min(15);
      }
    }
