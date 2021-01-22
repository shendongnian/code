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
    
           public new Company this[string responseString]
           {
                get { return (Company) BaseGet(responseString); }
                set
                {
                    if(BaseGet(responseString) != null)
                    {
                        BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                    }
                    BaseAdd(value);
                }
            }
    
    		protected override System.Configuration.ConfigurationElement CreateNewElement()
    		{
    			return new Company();
    		}
    
    		protected override object GetElementKey(System.Configuration.ConfigurationElement element)
    		{
    			return ((Company)element).Name;
    		}
    	}
