    public class ParentClass<T> where T : new() {
        public ParentClass() {
            var x = T.new();
        }
    }
    
    public class ChildClass : ParentClass<ChildClass> {
        public ChildClass() { }
    }
