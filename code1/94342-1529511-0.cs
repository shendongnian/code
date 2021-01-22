    List<Person> persons; // populated earlier
    using(StreamWriter wr = new StreamWriter("myfile.csv"))
    {
       foreach(Person person in persons)
       {
         wr.WriteLine(person.Name + "," + person.City + "," + person.Age);
       }
    }
