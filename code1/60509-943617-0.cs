    public class PersonFactory
    {
      private readonly ISettings settings;
      public PersonFactory(ISettings settings)
      {
        this.settings = settings;
      }
      public Person Create()
      {
         Person p = new Person();
         // ... you code for populating person's attributes form settings.
         return p;
      }
    }
