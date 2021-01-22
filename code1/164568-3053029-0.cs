    using System.Collections.ObjectModel;
    public class MyClass
    {
        private List<MyClass> children;
        public ReadOnlyCollection<MyClass> Children
        {
            get
            {
                return new ReadOnlyCollection<MyClass>(children);
            }
        }
    }
