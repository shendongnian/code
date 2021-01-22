    public class MyClass
    {
        void DoProcess(string Value) { // implementation }
        void DoProcess(int Value) { // implementation }\
        void DoProcess(MyClass Value) { // implementation }
        void DoProcess(object Value) { 
            // catch all method. Handle unknown entities, e.g. call ToString()
        }
        public void Process<T>(T value) {
           //this method will call the right overload of DoProcess depending on the compile time type of value. If there isn't a match, it goes to DoProcess(object)
           DoProcess(value);
        }
    }
