    public class CustomObject {
        public string AValue { get; set; }
        public bool BValue { get; set; }
        protected IXmlConfiguration Config = new CustomObjectConfig( );
    
        public virtual string ToXml( ) {
            return Config.ToXml( this );
        }
    
        public virtual void InitializeFromXml( string xml ) {
            Config.FromXml( xml );
            AValue = ((CustomObjectConfig)Config).A;
            BValue = ((CustomObjectConfig)Config).B;
        }
    }
    
    public interface IXmlConfiguration {
        void FromXml( string xml );
        string ToXml( object instance );
    }
    
    [XmlRoot( "CustomObject" )]
    public class CustomObjectConfig : IXmlConfiguration {
        [XmlElement( "AValue" )]
        public string A { get; set; }
        [XmlAttribute( "bvalue" )]
        public bool B { get; set; }
    
        public void FromXml( string xml ) {
            byte[] bytes = Encoding.UTF8.GetBytes( xml );
            using ( MemoryStream ms = new MemoryStream( bytes ) ) {
                XmlSerializer xs = new XmlSerializer( typeof( CustomObjectConfig ) );
                CustomObjectConfig cfg = (CustomObjectConfig)xs.Deserialize( ms );
                A = cfg.A;
                B = cfg.B;
            }            
        }
    
        public string ToXml( object instance ) {
            string xml = null;
            if ( instance is CustomObject ) {
                CustomObject val = (CustomObject)instance;
                A = val.AValue;
                B = val.BValue;
                using ( MemoryStream ms = new MemoryStream( ) ) {
                    XmlSerializer xs = new XmlSerializer( typeof( CustomObjectConfig ) );
                    xs.Serialize( ms, this );
                    ms.Seek( 0, 0 );
                    byte[] bytes = ms.ToArray( );
                    xml = Encoding.UTF8.GetString( bytes );
                }
            }
            return xml;
        }
    }
