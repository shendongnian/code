    interface IFoo  
    {  
      IFoo(int gottaHaveThis);  
      static Bar();  
    }
    interface ISummable
    {
          operator+(ISummable a, ISummable b);
    }
