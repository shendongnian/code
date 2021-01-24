    public class Sample
    {
        [DisplayName("Value"), Description("Value is something"), Category("Vectors"), ReadOnly(false)]
        [Editor(typeof(Vector2D), typeof(UITypeEditor))]
        public Vector2D Value { get; set; } 
    //Editor(typeof(Vector2D)) calls a class that handles the the editing of that value
        }
