    class MyObject
    {
         int ID {get;set;}
         string Name {get;set;}
         string Colour {get;set;}
         decimal Price {get;set;}
         List<decimal> Tax {get;set;}
         // Constructor
         public MyObject(DataRow row)
         {
              this.ID = Convert.ToInt32(row["ID"].ToString()); 
              this.Name = row["Name"].ToString();
              // etc....
         }
    }
