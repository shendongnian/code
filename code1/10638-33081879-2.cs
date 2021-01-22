    class FirstAndSecond : BaseClass, IFirst, ISecond {
      // link interface
      private class PartFirst : First {
        private FirstAndSecond ContainerInstance;
        public PartFirst(FirstAndSecond container) {
          ContainerInstance = container;
        }
        // forwarded references to emulate access as it would be with MI
        protected override void DoStuff() { ContainerInstance.DoStuff(); }
        protected override void DoSubClassStuff() { ContainerInstance.DoSubClassStuff(); }
      }
      private IFirst partFirstInstance; // composition object
      public FirstMethod() { partFirstInstance.FirstMethod(); } // forwarded implementation
      public FirstAndSecond() {
        partFirstInstance = new PartFirst(this); // composition in constructor
      }
      // same stuff for Second
      //...
      // implementation of DoSubClassStuff
      private void DoSubClassStuff() { Console.WriteLine("Private method accessed"); }
    }
