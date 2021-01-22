    partial class MyLinqClass {
        string Text = "Default";
    
        public AsOne() {
            Text = "One";
        }
    }
    
    var x = new MyLinqClass().AsOne();
