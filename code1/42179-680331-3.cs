    var myPerson = new SynchronicityHandler(new PersonValueHolder());
    
    // Safely setting values
    myPerson.WorkWithValueHolderSafely( p => 
         {
              p.FirstName = "Douglas";
              p.LastName = "Adams";
              p.HasCollegeDegree = true;
         }
    
    // Safely getting values (this syntax could be improved with a little effort)
    string theFirstName = null;
    
    myPerson.WorkWithValueHolderSafely( p=> theFirstName = p.FirstName);
    Console.Writeline("Name is: " + theFirstName); // Outputs "Name is: Douglass".
