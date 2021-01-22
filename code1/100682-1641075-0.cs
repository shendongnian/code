    var a = new Entity() { Name = "test", ID = "1" };
    var b = new Entity() { Name = "test", ID = "1" };
    var c = new Entity() { Name = "test", ID = "2" };
    System.Diagnostics.Debug.WriteLine(a.Equals(b));//Returns true
    System.Diagnostics.Debug.WriteLine(a.Equals(c));//Returns false
            
    public class Entity
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public override bool Equals(object obj)
        {
            var t = obj.GetType();
            var ta = t.GetProperties();
            foreach (var p in ta)
            {
                if (t.GetProperty(p.Name).GetValue(obj, null) != t.GetProperty(p.Name).GetValue(this, null))
                {
                    return false;
                }
            }
            return true;
        }
    }
