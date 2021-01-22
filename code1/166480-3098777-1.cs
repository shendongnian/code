    public class MyClass
    {
        public void Process(string Value) { // implementation }
        public void Process(int Value) { // implementation }\
        public void Process(MyClass Value) { // implementation }
        public void Process(object Value) { // catch all method. Handle unknown entities, e.g. call ToString() }
    }
