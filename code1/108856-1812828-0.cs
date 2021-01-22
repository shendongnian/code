    public interface IGroup
    {
        string ID { get; set; }  
        string Name { get; set; }  
        string ParentID { get; set; }  
        IList<IGroup> Groups { get; set; }
    }
    public class Group : IGroup
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ParentID { get; set; }
        public IList<IGroup> Groups { get; set; }
        public Group()
        {
            Groups = (IList<IGroup>)new List<Group>();
        }
        public Group(string id, string name, IList<IGroup> childs)
            : this()
        {
            ID = id;
            Name = name;
            Groups = childs;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> OriginalList;
            List<Group> HirarchList = new List<Group>();
            OriginalList = new List<Group>() 
            { 
                new Group() { ID = "g1", ParentID = null }, 
                new Group() { ID = "g2", ParentID = "g1" }, 
                new Group() { ID = "g3", ParentID = null }, 
                new Group() { ID = "g4", ParentID = "g3" }, 
                new Group() { ID = "g5", ParentID = "g4" }, 
                new Group() { ID = "g6", ParentID = "g5" } };
        }
        public static IList<IGroup> GetCreateList(string id, List<Group> list)
        {
            List<Group> temp = new List<Group>();
            temp = (from item in list 
                   where item.ParentID == id
                   select new Group(item.ID, item.Name,GetCreateList(item.ParentID, list))).ToList();
            return (IList<IGroup>)temp;
        }
    }
