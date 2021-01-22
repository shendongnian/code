    public interface IGroup
    {
        string ID { get; set; }  
        string Name { get; set; }  
        string ParentID { get; set; }  
        List<IGroup> Groups { get; set; }
    }
    public class Group : IGroup
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ParentID { get; set; }
        public List<IGroup> Groups { get; set; }
        public Group()
        {
        }
        public Group(string id, string name, List<IGroup> childs)
        {
            ID = id;
            Name = name;
            Groups = (List<IGroup>)childs.Cast<IGroup>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IGroup> OriginalList;
            List<IGroup> HirarchList = new List<IGroup>();
            OriginalList = new List<IGroup>() 
            { 
                new Group() { ID = "g1", ParentID = null }, 
                new Group() { ID = "g2", ParentID = "g1" }, 
                new Group() { ID = "g3", ParentID = null }, 
                new Group() { ID = "g4", ParentID = "g3" }, 
                new Group() { ID = "g5", ParentID = "g4" }, 
                new Group() { ID = "g6", ParentID = "g5" } };
            HirarchList = GetCreateList(null,  OriginalList);
        }
        public static List<IGroup> GetCreateList(string id, List<IGroup> list)
        {
            List<IGroup> temp = new List<IGroup>();
            temp = (from item in list 
                   where item.ParentID == id
                   select (IGroup)new Group(item.ID, item.Name,GetCreateList(item.ID, list))).ToList();
            return (List<IGroup>)temp;
        }
    }
