    public class Person : AbstractClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Profession Profession { get; set; }
    }
    public class Profession : AbstractClass
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public abstract class AbstractClass
    {
        public string GetString()
        {
            string values = string.Empty;
            foreach (System.Reflection.PropertyInfo pi in GetType().GetProperties())
            {
                if (pi.PropertyType.IsSubclassOf(typeof(AbstractClass)))
                    values += pi.Name + ": {" + (pi.GetValue(this) as AbstractClass).GetString() + "}, ";
                else
                    values += pi.Name + ": " + pi.GetValue(this) + ", ";
            }
            return values.Substring(0, Math.Max(0, values.Length - 2));
        }
    }
