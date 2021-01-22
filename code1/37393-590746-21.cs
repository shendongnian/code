    public class Derived : Base, ISerialize
    {
        public Derived()
        {
             m_type = Type.Derived;
        }
        public override virtual string ToXml()
        {
            string xml;
            // Serialize class Base to XML
            xml = base.ToXml();
            // Now serialize Derived to XML
            return string;
         }
         public override virtual void FromXml(string xml)
         {
             // Update object Base from xml
             base.FromXml(xml);
             // Update Derived from xml
         }
    };
