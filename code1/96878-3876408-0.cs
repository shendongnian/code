    partial class MyLinqClass {
        string Text = "Default";
    
        public MyLinqClass AsOne() {
            Text = "One";
            ...
            return this;
        }
    }
    
    var x = new MyLinqClass().AsOne();
    context.InsertOnSubmit(x); // x is type MyLinqClass
