    public class SuperHero : IComparable<SuperHero>
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Int32 ParentID { get; set; }
        public SuperHero(Int32 id, String name, Int32 pid)
        {
            this.ID = id;
            this.Name = name;
            this.ParentID = pid;
        }
        public Int32 CompareTo(SuperHero right)
        {
            return this.ParentID.CompareTo(right.ParentID);
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
