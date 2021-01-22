    class Program
    {
        static void Main(string[] args)
        {
            Person cenk = new Person() { adi = "Cenk", yasi = 18 };
            List<Person> lst = new List<Person>()
                                   {
                                       cenk,
                                       new Person() {adi = "Cem", yasi = 17, harfler = new[] {"a","b","c"}},
                                       new Person() {adi = "Canan", yasi = 16, harfler = new[] {"a","b","c"}}
                                   };
            DataTable dataTable = new DataTable();
            PropertyInfo[] pinfo = props();
            //var s = pinfo.Select(p => dataTable.Columns.Add(new DataColumn(p.Name, (p.PropertyType.FullName).GetType())));
            foreach (var p in pinfo)
            {
                dataTable.Columns.Add(new DataColumn(p.Name, p.PropertyType));
            }
            foreach (Person person in lst)
            {
                DataRow dr = dataTable.NewRow();
                foreach (PropertyInfo info in person.GetType().GetProperties())
                {
                    object oo = person.GetType().GetProperty(info.Name).GetValue(person, null);
                    dr[info.Name] = oo;
                }
                dataTable.Rows.Add(dr);
            }
        }
        static public PropertyInfo[] props()
        {
            return (new Person()).GetType().GetProperties();
        }
    }
    public class Person
    {
        public string adi { get; set; }
        public int yasi { get; set; }
        public string[] harfler { get; set; }
    }
