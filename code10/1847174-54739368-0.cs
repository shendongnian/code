    // Mapp a key to an index
    public class IndexAttribute: Attribute(){
    public int Index { get; private set; }
    public IndexAttribute(int index){
    Index = index;
    }
    }
    public class FrameData
    {
        [IndexAttribute(0)]
        public string SecurityId { get; set; }
        [IndexAttribute(3)]
        public string FieldName { get; set; }
        [IndexAttribute(2)]
        public DateTime Date { set; get; }
        [IndexAttribute(1)]
        public decimal value { get; set; }
    }
    // create a class the convert the frame to class
    public static List<T> Convert<T>(this DataTable data) where T: class
    {
      var list = new List<T>();
      foreach(var row in data.Rows){
       object item = Activator.CreateInstance(typeof(T));
       var props = typeof(T).GetProperties();
       foreach(var p in props){
        var index = p.GetCustomAttribute<IndexAttribute>()?.Index ?? -1;
        if (index< 0)
           continue;
           
          if (table.Columns.length > index) // if the index exist
          {
            var value = row[index]; // get the value.
            if (value == null)
             continue; // ignore null value
            if (prop.PropertyType == typeof(string))
             prop.SetValue(item, value.ToString());
           if (prop.PropertyType == typeof(DateTime))
              prop.SetValue(item, DateTime.Parse(value.ToString()));
              
            // .. now check for decimal, int etc
          }
        }
        list.Add(item);
      }
      return list;
    }
    And now all you need is to call the function
    List<Person> persons = df.Convert<Person>(); // that all
