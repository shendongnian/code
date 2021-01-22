    public interface ICustomControl {
         string MyProperty { get; set;}
    }
    public class CustomControl : UserControl, ICustomControl {
         public string MyProperty { get; set; }
    }
...
    ICustomControl cControl = new CustomControl();
