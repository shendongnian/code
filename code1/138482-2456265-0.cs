    interface IVisitor {
     Visit(SomeClass c);
     Visit(AnotherClass c);
    }
    
    interface IAcceptVisitor {
      void Accept(IVisitor v);
    }
    
    public SomeClass : IAcceptVisitor {
      void Accept(IVisitor v) {
        v.Visit(this);
      }
    }
