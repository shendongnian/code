    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SomeAttribute : Attribute
    {
        public SomeAttribute() { }
        public SomeAttribute(int SomeVariable)
        {
            this.SomeVariable = SomeVariable;
        }
        public int SomeVariable
        {
            get;
            set;
        }
    }
    /* Here's the true ambiguity: When you add an attribute, and only in this case
     * there would be no way without a new syntax to use named arguments with attributes.
     * This is a particular problem because attributes are a prime candidate for
     * constructor simplification for immutable data types.
     */
    // This calls the constructor with 1 arg
    [Some(SomeVariable: 3)]
    // This calls the constructor with 0 args, followed by setting a property
    [Some(SomeVariable = 3)]
    public class SomeClass
    {
    }
