    public enum VisibilitySpecifier
    {
        A,
        B,
    }
    public class AndVisibleToAttribute : Attribute
    {
        public VisibilitySpecifier[] Visibility { get; set; }
        public AndVisibleToAttribute(params VisibilitySpecifier[] visibility)
        {
            Visibility = visibility;
        }
    }
    public class OrVisibleToAttribute : Attribute
    {
        public VisibilitySpecifier[] Visibility { get; set; }
        public OrVisibleToAttribute(params VisibilitySpecifier[] visibility)
        {
            Visibility = visibility;
        }
    }
