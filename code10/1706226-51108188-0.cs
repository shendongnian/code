    class Model
    {
        [Column.PrimaryKey(AutoIncrement = true)]
        public int ID { get;set; }
    
        [Column.Null]
        public string Name { get; set; }
        [Relation.OneToMany(ForeignKey="ParentID")    
        public List<ChildModel> Objects {get;set;} = new List<ChildModel>();
    }
    
    class ChildModel
    {
        [Column.PrimaryKey(AutoIncrement = true)]
        public int ID { get;set; }
        public int ParentID {get;set;}
    
        [Column.Null]
        public string Name { get; set; }
    }
