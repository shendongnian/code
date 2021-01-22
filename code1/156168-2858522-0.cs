        [Serializable]
    	public class Typed<T>
    	{
    		public Typed()
    		{
    		}
    
    		public Typed( T value )
    		{
                 this.Value = value;
    		}
    
    		[XmlText]
    		public T Value { get; set; }
    
    		[XmlAttribute( "Type" )]
    		public String Type
    		{
    			get
    			{
    				return typeof( T ).Name;
    			}
    			set
    			{
                    // Skipped for clarity
    			}
    		}
    	}
