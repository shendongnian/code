    /// <summary>
    /// Property Descriptor for Test Result Row Wrapper
    /// </summary>
    public class TestResultPropertyDescriptor : PropertyDescriptor
    {
        //- PROPERTIES --------------------------------------------------------------------------------------------------------------
     
        #region Properties
     
        /// <summary>
        /// Component Type
        /// </summary>
        public override Type ComponentType
        {
            get { return typeof(Dictionary<string, TestResultValue>); }
        }
     
        /// <summary>
        /// Gets whether its read only
        /// </summary>
        public override bool IsReadOnly
        {
            get { return false; }
        }
     
        /// <summary>
        /// Gets the Property Type
        /// </summary>
        public override Type PropertyType
        {
            get { return typeof(string); }
        }
     
        #endregion Properties
     
        //- CONSTRUCTOR -------------------------------------------------------------------------------------------------------------
     
        #region Constructor
     
        /// <summary>
        /// Constructor
        /// </summary>
        public TestResultPropertyDescriptor(string key)
            : base(key, null)
        {
     
        }
     
        #endregion Constructor
     
        //- METHODS -----------------------------------------------------------------------------------------------------------------
     
        #region Methods
     
        /// <summary>
        /// Can Reset Value
        /// </summary>
        public override bool CanResetValue(object component)
        {
            return true;
        }
     
        /// <summary>
        /// Gets the Value
        /// </summary>
        public override object GetValue(object component)
        {
              return ((Dictionary<string, TestResultValue>)component)[base.Name].Value;
        }
     
        /// <summary>
        /// Resets the Value
        /// </summary>
        public override void ResetValue(object component)
        {
            ((Dictionary<string, TestResultValue>)component)[base.Name].Value = string.Empty;
        }
     
        /// <summary>
        /// Sets the value
        /// </summary>
        public override void SetValue(object component, object value)
        {
            ((Dictionary<string, TestResultValue>)component)[base.Name].Value = value.ToString();
        }
     
        /// <summary>
        /// Gets whether the value should be serialized
        /// </summary>
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
     
        #endregion Methods
     
        //---------------------------------------------------------------------------------------------------------------------------
    }
