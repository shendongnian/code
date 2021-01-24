     class Persons
     {
       public List<Person> PersonsList {get;set;}
       public Person this[int index]
       {
         return PersonsList[index];
       }
     }
