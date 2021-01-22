    public class Person
    {
        public string Name { get; set; }
    }
    public class Employee
    {
        public Person person = new Person();
        public void DynamicallySetPersonProperty()
        {
            var p = GetType().GetField("person").GetValue(this);
            p.GetType().GetProperty("Name").SetValue(p, "new name", null);
        }
    }
