    class A
    {
    
        public void DoStuff() {
            var x = DoGetX();
            Console.WriteLine(x);
        }
        protected abstract int DoGetX();
    }
    
    class B : A
    {
        protected override int DoGetX() {
          return 1;
        }
    }
