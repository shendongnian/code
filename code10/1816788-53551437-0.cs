    public class C1 {
        public virtual void A() { Console.WriteLine("Good"); }
        public void B() { A(); }
    }
    public class C2 : C1 {
        bool _aOnCallStack = false;
        public override void A() { 
            if (!_aOnCallStack) {
                _aOnCallStack = true;
                B(); 
            }
            else {
                base.A();
                _aOnCallStack = false;
            }
        }
    }
