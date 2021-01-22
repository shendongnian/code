    public class MyCustomLabel : Label
     {
        // Either use the [DesignerSerialization...]
        // OR override and make the FONT as READ-ONLY (via only a GETTER)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        { get { return new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);; } }
    
        ...
        ...
    
    }
