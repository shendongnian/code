    using System.Linq;
    DataTable dt = new DataTable();            
    dt = myClass.myMethod();                 
    List<object> list = (from row in dt.AsEnumerable() select (row["name"])).ToList();
    comboBox1.DataSource = list;
