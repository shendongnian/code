    interface IBasicProps {
       int Priority { get; }
       string Name {get;}
       //... whatever
    }
    
    interface IBasicPropsWriteable:IBasicProps  {
       new int Priority { get; set; }
       new string Name { get; set; }
       //... whatever
    }
    class Foo : IBasicPropsWriteable {
        public int Priority {get;set;}
        public string Name {get;set;}
    /* optional
        int IBasicProps.Priority {get {return Priority;}}
        string IBasicProps.Name {get {return Name;}}
    */
    }
