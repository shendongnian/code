    public class ParentClass<T> where T : ParentClass<T>, new() { // fixed
        public ParentClass() {
            var x = new T(); // fixed, was T.new()
        }
    }
    
    public class ChildClass : ParentClass<ChildClass> {
        public ChildClass() { }
    }
