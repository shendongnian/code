    public abstract class BaseClass
    {
        public abstract Image LabelTexture { get; }
        // ... other stuff
    }
    public class ClassA : BaseClass
    {
        public override Image LabelTexture => sprite.texture;
    }
    
    public class ClassB : BaseClass
    {
        public override Image LabelTexture => animated[0].texture;
    }
    public class ClassC : BaseClass
    {
        public override Image LabelTexture => default.texture;
    }
