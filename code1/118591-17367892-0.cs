    abstract class TestBase
    {
        public abstract int Int { get; }
    }
    class TestDerivedHelper : TestBase
    {
        private int _Int;
        public override int Int
        {
            get
            {
                return _Int;
            }
        }
    
        protected void SetInt(int value)
        {
            this._Int = value;
        }
    }
    
    class TestDerived : TestDerivedHelper
    {
        public new int Int
        {
            get { return base.Int; }
            set { base.SetInt(value); }
        }
    }
