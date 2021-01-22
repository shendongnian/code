    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    
    [Serializable]
    public class Test : ISerializable
    {
        private Test(SerializationInfo info, StreamingContext context)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Test));
    
            foreach (SerializationEntry entry in info)
            {
                PropertyDescriptor property = properties.Find(entry.Name, false);
                property.SetValue(this, entry.Value);
            }
        }
        
        [SecurityPermission(SecurityAction.LinkDemand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Test));
    
            foreach (PropertyDescriptor property in properties)
            {
                info.AddValue(property.Name, property.GetValue(this));
            }
        }
    }
