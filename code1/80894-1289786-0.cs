    interface ICustomizableObject
    {
        string SomeProperty { get; }
    }
    
    public static class CustomizableObject
    {
        public static string XamlHeader(this ICustomizableObject obj)
        {
            return DoSomethingWith(obj.SomeProperty);
        }
    
        // etc
    }
    
    public class SpriteAnimation : Sprite, ICustomizableObject
    {
        public string SomeProperty { get { return "SpriteAnimation"; } }
    }
