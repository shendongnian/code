    interface IAcceptor
    {
      void Accept(IVisitor visitor);
    }
    
    interface IVisitor
    {
      void Visit(Type1 type1);
      void Visit(Type2 type2);
      .. etc ..
    }
