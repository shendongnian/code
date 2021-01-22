      public class BaseRecord
      {
         public bool isDirty;
         public object[] itemArray;
         public static string[] columnNames;
         public void DisplayColumnNames()
         {
            foreach (string s in columnNames)
               Console.Write("{0}\n", s);
         }
         
         public void DisplayItem()
         {
            for (int i = 0; i < itemArray.Length; i++)
            {
               Console.Write("{0}: {1}\n", columnNames[i], itemArray[i]);
            }
         }
      }
      public class PeopleRec : BaseRecord
      {
         public PeopleRec()
         {
            PeopleRec.columnNames = new string[2];
            PeopleRec.columnNames[0] = "FIRST_NAME";
            PeopleRec.columnNames[1] = "LAST_NAME";
         }
      }
      public class OrderRec : BaseRecord
      {
         public OrderRec()
         {
            OrderRec.columnNames = new string[4];
            OrderRec.columnNames[0] = "ORDER_ID";
            OrderRec.columnNames[1] = "LINE";
            OrderRec.columnNames[2] = "PART_NO";
            OrderRec.columnNames[3] = "QTY";
         }
      }
      public static void Main()
      {
         BaseRecord p = new PeopleRec();
         p.DisplayColumnNames();
         p.itemArray = new object[2];
         p.itemArray[0] = "James";
         p.itemArray[1] = "Smith";
         p.DisplayItem();
         BaseRecord o = new OrderRec();
         o.DisplayColumnNames();
         o.itemArray = new object[4];
         o.itemArray[0] = 1234;
         o.itemArray[1] = 1;
         o.itemArray[2] = 39874;
         o.itemArray[3] = 70;
         o.DisplayItem();
      }
