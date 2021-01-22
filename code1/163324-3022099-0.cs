    class A
    {
        public virtual void DoStuff(int x) {
            Console.WriteLine(x);
        }
    }
    class B : A
    {
        public override void DoStuff(int x) {
            //do stuff
            int y = 1
            base.DoStuff(y);
        }
    }
