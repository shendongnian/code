    public class Person
    {
      private int id;
      private string fName;
      private string addre;
      public string Addre
      {
         get { return addre; }
         set { addre = value; }
      }
      public string FName
      {
         get { return fName; }
         set { fName = value; }
      }
      public int ID
      {
         get { return id; }
         set { id = value; }
      }
      public Person(int i, string f, string a)
      {
         ID = i;
         FName = f;
         Addre = a;
      }
     }
