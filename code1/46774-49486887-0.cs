    public class Parent
    {
        public CHILD1 Child1;
        public CHILD2 Child2;
		
        public Parent(params args){
            Child1 = new CHILD1(arg1, arg2);
            Child2 = new CHILD2(arg1, arg2);
        }
        //split here
        public Parent(object arg1, object arg2) {
            PropertyInfo[] list = this.GetType().GetProperties();
            foreach (var pi in list) {
				pi.SetValue(this, BL.Method(arg1, arg2, this.GetType().Name, pi.Name) // get data
			}
        }
    }
    public class CHILD1 : Parent
    {
        public CHILD1(object arg1, object arg2) : base(arg1, arg2) { }
		
        public object C1Property1 { get; set; }
        public object C1Property2 { get; set; }
		// ..
	}
    public class CHILD2 : Parent
    {
        public CHILD2(object arg1, object arg2) : base(arg1, arg2) { }
		
        public object C2Property1 { get; set; }
        public object C2Property2 { get; set; }
		// ..
	}
