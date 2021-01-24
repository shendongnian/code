    public class Child: Parent {
        public Child()
        {
			var baseClass = GetType().BaseType;
	        dynamic instance_of_Parent = Activator.CreateInstance(baseClass);
	    }
	}
