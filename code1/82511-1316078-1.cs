    public class Companies
    		: ConfigurationElementCollection
    	{
    		public Company this[int index]
    		{
    			get
    			{
    				return base.BaseGet(index) as Company ;
    			}
    			set
    			{
    				if (base.BaseGet(index) != null)
    				{
    					base.BaseRemoveAt(index);
    				}
    				this.BaseAdd(index, value);
    			}
    		}
    
    
    		protected override System.Configuration.ConfigurationElement CreateNewElement()
    		{
    			return new Company();
    		}
    
    		protected override object GetElementKey(System.Configuration.ConfigurationElement element)
    		{
    			return ((Company)element).Key;
    		}
    	}
