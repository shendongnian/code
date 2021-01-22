    var contact = new Contact(
                      new PersonalName("James", "Bond"),
                      new ContactInfo(
                          new EmailAddress("agent@007.com")
                      )
                   );
    Console.WriteLine(contact.PersonalName()); // James Bond
    Console.WriteLine(contact.ContactInfo().???) // here we have problem, because ContactInfo have three possible state and if we want print it we would write `if` cases
