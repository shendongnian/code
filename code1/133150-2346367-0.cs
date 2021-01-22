    public class EntityInfo
    {
    private String _id;    
    public int ID { 
    get {return _id.ToString();}
    set {_id = Convert.ToInt32(value);}; 
    }
        public String Type { get; set; }
    }
-----
    return from item in session.Linq<ObjectType>()
           select new EntityInfo() { item.ID, item.ClassName };
