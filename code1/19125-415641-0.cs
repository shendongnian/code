    /// <summary>
    /// Provides a description for an enumerated type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, 
     AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute :  Attribute
    {
       private string description;
    
       /// <summary>
       /// Gets the description stored in this attribute.
       /// </summary>
       /// <value>The description stored in the attribute.</value>
       public string Description
       {
          get
          {
             return this.description;
          }
       }
    
       /// <summary>
       /// Initializes a new instance of the
       /// <see cref="EnumDescriptionAttribute"/> class.
       /// </summary>
       /// <param name="description">The description to store in this attribute.
       /// </param>
       public EnumDescriptionAttribute(string description)
           : base()
       {
           this.description = description;
       }
    } 
