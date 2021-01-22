    [AttributeUsage(AttributeTargets.Field)]
    public class ShapeDescriptionAttribute: Attribute
    {
        #region Constructor
        public ShapeDescriptionAttribute(ShapeType shapeType, string name) : this(shapeType, name, name) { }
        public ShapeDescriptionAttribute(ShapeType shapeType, string name, string description)
        {
            Description = description;
            Name = name;
            Type = shapeType;
        }
        #endregion
        #region Public Properties
        public string Description { get; protected set; }
        public string Name { get; protected set; }
        
        public ShapeType Type { get; protected set; }
        #endregion
    }
