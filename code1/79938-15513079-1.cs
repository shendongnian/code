    // File1.cs
    public partial class Example
    {
        public Example()
        {
            // Add code here to find & invoke methods with custom attribute "Initialize".
        }
        [AttributeUsage(AttributeTargets.Method)]
        public class InitializeAttribute : Attribute
        {
            // Whatever you want here.
        }
    }
    // File2.cs
    partial class Example
    {
        [Initialize]
        public void RandomMethod()
        {
            // This will be run automatically with a new instance of the object.
            // It's just like it's part of the constructor.
            // There is no limit to these. You can have lots of generated code pages.
        }
    }
