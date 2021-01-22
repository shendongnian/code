    public class MyClass
    {
      public DateTime dateTime;
      public int ID;
    }
    private void button1_Click(object sender, EventArgs e)
    {
      List<MyClass> list = new List<MyClass>();
    
      list.Add(new MyClass() { dateTime = new DateTime(2009, 01, 01), ID = 1 });
      list.Add(new MyClass() { dateTime = new DateTime(2009, 02, 01), ID = 1 });
      list.Add(new MyClass() { dateTime = new DateTime(2009, 02, 01), ID = 2 });
    
      var dd = from d in list
                         group d by d.ID into g
                         let MaxDate = g.Max(u => u.dateTime)
                         select new { g.Key, MaxDate };
     }
