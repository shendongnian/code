    public class MyControl {
    
        // be prepared for some dependency property hell below
        // this defines a DependencyProperty whose value will be inherited
        // by child elements in the visual tree that do not override
        // the value. An example of such a property is the FontFamily
        // property. You can set it on a parent element and it will be
        // inherited by child elements that do not override it.
    
        public static readonly DependencyProperty MyInheritedProperty =
            DependencyProperty.Register(
                "MyInherited",
                typeof(string),
                typeof(MyControl),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.Inherits
                )
            );
    
    }
