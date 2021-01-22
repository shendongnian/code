    public class MyClass_Base
    {
		public MyClass_Base() 
		{
			/// Don't call the InitClass() when the object is inherited
			/// !!! CAUTION: The inherited constructor must call InitClass() itself when init is needed !!!
			if (this.GetType().IsSubclassOf(typeof(MyClass_Base)) == false)
			{
				this.InitClass();
			}
		}
		
		protected void InitClass()
		{
			// The init stuff
		}
	}
    public class MyClass : MyClass_Base
    {
        public MyClass(bool callBaseClassInit)
        {
			if(callBaseClassInit == true)
				base.InitClass();
        }
    }
