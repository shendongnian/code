    class Derived : Base
    {
        protected bool _useBaseSay = false;
        
        public override void Say()
        {
            if(this._useBaseSay)
                base.Say();
            else
                Console.WriteLine("Called from Derived");
        }
    }
