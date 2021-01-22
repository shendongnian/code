    /// <summary>
    /// Class to manage test result row data functions
    /// </summary>
    public class TestResultRowWrapper : Dictionary<string, TestResultValue>, ICustomTypeDescriptor
    {
        //- METHODS -----------------------------------------------------------------------------------------------------------------
     
        #region Methods
     
        /// <summary>
        /// Gets the Attributes for the object
        /// </summary>
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return new AttributeCollection(null);
        }
     
        /// <summary>
        /// Gets the Class name
        /// </summary>
        string ICustomTypeDescriptor.GetClassName()
        {
            return null;
        }
     
        /// <summary>
        /// Gets the component Name
        /// </summary>
        string ICustomTypeDescriptor.GetComponentName()
        {
            return null;
        }
     
        /// <summary>
        /// Gets the Type Converter
        /// </summary>
        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return null;
        }
     
        /// <summary>
        /// Gets the Default Event
        /// </summary>
        /// <returns></returns>
        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return null;
        }
     
        /// <summary>
        /// Gets the Default Property
        /// </summary>
        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return null;
        }
     
        /// <summary>
        /// Gets the Editor
        /// </summary>
        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return null;
        }
     
        /// <summary>
        /// Gets the Events
        /// </summary>
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return new EventDescriptorCollection(null);
        }
     
        /// <summary>
        /// Gets the events
        /// </summary>
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return new EventDescriptorCollection(null);
        }
     
        /// <summary>
        /// Gets the properties
        /// </summary>
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            List<propertydescriptor> properties = new List<propertydescriptor>();
     
            //Add property descriptors for each entry in the dictionary
            foreach (string key in this.Keys)
            {
                properties.Add(new TestResultPropertyDescriptor(key));
            }
     
            //Get properties also belonging to this class also
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(this.GetType(), attributes);
     
            foreach (PropertyDescriptor oPropertyDescriptor in pdc)
            {
                properties.Add(oPropertyDescriptor);
            }
     
            return new PropertyDescriptorCollection(properties.ToArray());
        }
     
        /// <summary>
        /// gets the Properties
        /// </summary>
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(null);
        }
     
        /// <summary>
        /// Gets the property owner
        /// </summary>
        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
     
        #endregion Methods
     
        //---------------------------------------------------------------------------------------------------------------------------
    }
