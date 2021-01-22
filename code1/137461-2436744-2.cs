    [AttributeUsage(AttributeTargets.Property)]
    public class MyPropertyAttribute : Attribute
    {
        public enum VisibilityOptions
        {
            visible,
            invisible
        }
        private VisibilityOptions visibility = VisibilityOptions.visible;
        public MyPropertyAttribute(VisibilityOptions visibility)
        {
            this.visibility = visibility;
        }
        public VisibilityOptions Visibility
            {
                get
                {
                    return visibility;
                }
                set
                {
                    visibility = value;
                }
            }
    }
