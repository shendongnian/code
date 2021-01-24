    using System;
    using System.Data
    
    public class Program
    {
       public static void Main()
       {
           using (var dt = new DataTable())
           {
               // the data in the table - one row one column
               var person = new
               {
                   Name = "ABC",
                   Age = 24
               };
               // setup data table
               dt.Columns.Add("Column1",typeof(object));
               var row = dt.NewRow();
               row["Column1"] = person;
               dt.Rows.Add(row);
               // assert
               var storedPerson = dt.Rows[0]["Column1"];
               if(!ReferenceEquals(dt.Rows[0].ItemArray[0], storedPerson))
                throw new Exception();
               if(!ReferenceEquals(storedPerson, person)){
                   Console.WriteLine("What is going on?");
                   Console.WriteLine($"Person is stored as a [{storedPerson.GetType().Name}]!");
                   Console.WriteLine($"Why is it not of type: [{person.GetType().Name}]?");
               }
           }
        }
    }
