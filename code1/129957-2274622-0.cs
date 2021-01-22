    namespace SecurityLibrary
    {
        public class MutableReferenceTypes
        {
            static protected readonly StringBuilder SomeStringBuilder;
    
            static MutableReferenceTypes()
            {
                // allowed
                SomeStringBuilder = new StringBuilder();
            }
            void Foo()
            {
                // not allowed
                SomeStringBuilder = new StringBuilder();
            }
            void Bar()
            {
                // allowed but FXCop doesn't like this
                SomeStringBuilder.AppendLine("Bar");
            }
        }
    }
