         static void AddToContacts(Person person)
         {
           // This method adds a Person object
           // to a contact list.
         }
         // The Action delegate expects 
         // a method that has an Employee parameter,
         // but you can assign it a method that has a Person parameter
         // because Employee derives from Person.
         Action<Employee> addEmployeeToContacts = AddToContacts;
