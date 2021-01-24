      class Parent
    {
        public virtual int ID { get { return 40; } }
    }
    class ChildWithNew: Parent
    {
        public new int ID { get { return 50; } }
    }
    class ChildWithOverride : Parent
    {
        public override int ID { get { return 60; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Child with Override Kyword");
            ChildWithOverride cildWithOverride = new ChildWithOverride();
            Console.WriteLine(cildWithOverride.ID);
            Console.WriteLine(((Parent)cildWithOverride).ID);
            Console.WriteLine("---Child with New Kyword");
            ChildWithNew childWithNew = new ChildWithNew();
            Console.WriteLine(childWithNew.ID);
            Console.WriteLine(((Parent)childWithNew).ID);
            Console.ReadLine();
        }
         
 
    }
