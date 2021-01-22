    public static void Main()
    {
      using (MyObjectContext context = new MyObjectContext())
      {
        //Using method 1 - collection provided as collection
        var contacts1 =
          context.Contacts.WhereIn(c => c.Name, GetContactNames());
        //Using method 2 - collection provided statically
        var contacts2 = context.Contacts.WhereIn(c => c.Name,
          "Contact1",
          "Contact2",
          "Contact3",
          "Contact4"
          );
      }
    }
