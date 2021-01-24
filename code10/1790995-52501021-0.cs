    public class MenuStyle : StyleSelector
    {
        // Declare all the style you're going to need right here
        public Style StyleMenuItem { get; set; }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            // here you can check which type item is and return the corresponding style
            if(item != null && typeof(item) == typeof(YourType))
            {
                 return StyleMenuItem;
            }
        }
    }
