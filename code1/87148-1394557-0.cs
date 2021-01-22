    public class DefaultPage : Page {
        public string MyProperty { get; set; }
    } 
    public class DefaultControl : UserControl {
        //...
        ((DefaultPage)this.Page).MyProperty
        //...
    }
