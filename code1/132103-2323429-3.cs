    class Derived : Base
    {
        protected enum Mode
        {
            Standard,
            BaseFunctionality,
            Verbose
            //etc
        }
        protected Mode Mode
        {
            get; set;
        }
        
        public override void Say()
        {
            if(this.Mode == Mode.BaseFunctionality)
                base.Say();
            else
                Console.WriteLine("Called from Derived");
        }
    }
