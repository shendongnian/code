        [DataContract(Name = "SomeObject", Namespace = "http://schemas.domain.com/namespace/")]    
        [Namespace(Prefix = "a", Uri = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]    
        [Namespace(Prefix = "wm", Uri = "http://schemas.datacontract.org/2004/07/System.Windows.Media")]           
        public class SomeObject : SerializableObject          
        {    
            private IList<Color> colors;
            [DataMember]
            [DisplayName("Colors")]
            public IList<Colors> Colors
            {
                get { return colors; }
                set { colours = value; }
            }
        }
