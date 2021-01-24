    public class ClassName : IEquatable<ClassName>
    {
        public int ID;
        public String n_1 { get; set; }
        public String n_2 { get; set; }
        // ....
        public String n_x { get; set; }
        public static bool operator ==(ClassName obj1, ClassName obj2) =>
            obj1.Equals(obj2);
            
        public static bool operator != (ClassName obj1, ClassName obj2) =>
            !obj1.Equals(obj2);
        public bool Equals(ClassName obj)
        {
            if (obj == null) return false;
            return (n_1 == obj.n_1) && (n_2 == obj.n_2) && (n_x == obj.n_x); //you can ignore ID here
        }
    }
