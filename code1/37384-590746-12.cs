    public class Base : ISerialize
    {
        public enum Type
        {
            Base,
            Derived
        };
        public Type m_type;
        public Base()
        {
            m_type = Type.Base;
        }
        public virtual string ToXml()
        {
            string xml;
            // Serialize class Base to XML
            return string;
         }
    
        public virtual void FromXml(string xml)
        {
            // Update object Base from xml
        }
    };
