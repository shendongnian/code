    class Person {
        private int age;
        private string name;
        private string sex;
        public object this[string name]
        {
    	    get
    	    {
    		PropertyInfo property = GetType().GetField(name);
    		return property.GetValue(this, null);
    	    }
            set
    	    {
    		PropertyInfo property = GetType().GetField(name);
    		property.SetValue(this, value, null);
    	    }
        }
    }
