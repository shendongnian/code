     DateTime date = new DateTime(2010, 4, 29, 10, 25, 00);
     TimeSpan t = new TimeSpan(1, 0, 0, 0);
    
     // The change is here, setting date to be the *new* date produced by calling Add
     date = date.Add(t);
    
     Console.WriteLine("A day after the day: " + date.ToString());
