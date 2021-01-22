    public class Person
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void PropertySet(object p, string propName, object value)
        {
            Type t = p.GetType();
            PropertyInfo info = t.GetProperty(propName);
            if (info == null)
                return;
            if (!info.CanWrite)
                return;
            info.SetValue(p, value, null);
        }
        static void PropertySetLooping(object p, string propName, object value)
        {
            Type t = p.GetType();
            foreach (PropertyInfo info in t.GetProperties())
            {
                if (info.Name == propName && info.CanWrite)
                {
                    info.SetValue(p, value, null);
                }
            }
        }
        static void Main(string[] args)
        {
            Person p = new Person();
            PropertySet(p, "Name", "Michael Ellis");
            Console.WriteLine(p.Name);
            PropertySetLooping(p, "Name", "Nigel Mellish");
            Console.WriteLine(p.Name);
        }
    }
