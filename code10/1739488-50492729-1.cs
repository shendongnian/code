    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    
    namespace PropertyGridSample
    {
        [TypeConverter(typeof(LayerConverter))]
        public class Layer
        {
            public Image image { get; set; }
    
            public Layer() { }
        }
    
        public class Layers
        {
            LayerCollection layercollection = new LayerCollection();
    
            public Layers()
            {
                Layer[] layz = new Layer[2];
                 
                Layer lay1 = new Layer(); Layer lay2 = new Layer(); //Create two test layers and add them to the layer collection
    
                layercollection.Add(lay1); layercollection.Add(lay2);
            }
    
            [TypeConverter(typeof(LayerCollectionConverter))]
            public LayerCollection Layer_Collection { get { return layercollection; } }
        }
    
        public class LayerCollection : CollectionBase, ICustomTypeDescriptor
        {
            #region collection impl
                public void Add(Layer lay) { List.Add(lay); } //Adds a layer object to the collection
                public void Remove(Layer lay) { List.Remove(lay); } //Removes a layer object from the collection
    
                public Layer this[int index] { get { return (List.Count > -1 && index < List.Count) ? (Layer)List[index] : null; } } //Return a layer object at index position
            #endregion
    
            #region ICustomTypeDescriptor impl 
                public AttributeCollection GetAttributes() { return TypeDescriptor.GetAttributes(this, true); }
    
                public String GetClassName() { return TypeDescriptor.GetClassName(this, true); }
                public String GetComponentName() { return TypeDescriptor.GetComponentName(this, true); }
        
                public TypeConverter GetConverter() { return TypeDescriptor.GetConverter(this, true); }
    
                public EventDescriptor GetDefaultEvent() { return TypeDescriptor.GetDefaultEvent(this, true); }
                public PropertyDescriptor GetDefaultProperty() { return TypeDescriptor.GetDefaultProperty(this, true); }
    
                public EventDescriptorCollection GetEvents(Attribute[] attributes) { return TypeDescriptor.GetEvents(this, attributes, true); }
                public EventDescriptorCollection GetEvents() { return TypeDescriptor.GetEvents(this, true); }
    
                public object GetEditor(Type editorBaseType) { return TypeDescriptor.GetEditor(this, editorBaseType, true); }
                public object GetPropertyOwner(PropertyDescriptor pd) { return this; }
    
                //Called to get the properties of this type. Returns properties with certain attributes. this restriction is not implemented here.
                public PropertyDescriptorCollection GetProperties(Attribute[] attributes) { return GetProperties(); }
    
                //Called to get the properties of this type.
                public PropertyDescriptorCollection GetProperties()
                {            
                    PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null); // Create a collection object to hold property descriptors
    
                    // Iterate the list of layers and create a property descriptor for each layer item and add to the property descriptor collection
                    for (int i = 0; i < this.List.Count; i++) { LayerCollectionPropertyDescriptor pd = new LayerCollectionPropertyDescriptor(this, i); pds.Add(pd); }
                    
                    return pds; // return the descriptor collection
                }
            #endregion
        }
    
        class LayerConverter : ExpandableObjectConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
            {
                return (destType == typeof(string) && value is Layer) ? "Layer Data": base.ConvertTo(context, culture, value, destType);
            }
        }
    
        class LayerCollectionConverter : ExpandableObjectConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
            {
                return  (destType == typeof(string) && value is LayerCollection) ? "Items": base.ConvertTo(context, culture, value, destType);
            }
        }
    
        public class LayerCollectionPropertyDescriptor : PropertyDescriptor
        {
            private LayerCollection collection = null;
            private int index = -1;
    
            public LayerCollectionPropertyDescriptor(LayerCollection coll, int idx) : base("#" + idx.ToString(), null)
            {
                collection = coll; index = idx;
            }
    
            public override AttributeCollection Attributes { get { return new AttributeCollection(null); } }
    
            public override bool CanResetValue(object component) { return true; }
            public override bool IsReadOnly { get { return false; } }
            public override bool ShouldSerializeValue(object component) { return true; }
    
            public override string Description { get { return "Layer Description"; } }
            public override string DisplayName { get { return "Layer " + index.ToString(); } }
            public override string Name { get { return "#" + index.ToString(); } }
    
            public override object GetValue(object component) { return collection[index]; }
    
            public override Type ComponentType { get { return collection.GetType(); } }
            public override Type PropertyType { get { return collection[index].GetType(); } }
    
            public override void ResetValue(object component) { }
            public override void SetValue(object component, object value) { } // this.collection[index] = value;
        }
    }
