      interface IMoveable
      {
        public void Act();
      }
    
      interface IRollable
      {
        public void Act();
      }
    
      class Thing : IMoveable, IRollable
      {
        //TODO Roll/Move code here
    
        void IRollable.Act()
        {
          Roll();
        }
    
        void IMoveable.Act()
        {
          Move();
        }
      }
