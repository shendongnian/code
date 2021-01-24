    class Parent {
        public Guid Id {get;set;}
    }
    
    class Child {
        public Guid Id {get;set;}
        public Guid ParentId {get;set;}
        public Parent Parent {get;set;}
    }
    
