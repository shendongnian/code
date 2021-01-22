    public class MyClass()
    {
        private IHelper _helper;
        public MyClass()
        {
            //Default constructor normal code would use.
            this._helper = new Helper();
        }
        public MyClass(IHelper helper)
        {
            if(helper == null)
            {
                throw new NullException(); //I forget the exact name but you get my drift ;)
            }
            this._helper = helper;
        }
        public void LoadData()
        {
            SomeProperty = this._helper.GetSomeData();
        }
        public object SomeProperty {get;set;}
    }
