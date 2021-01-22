    internal struct ModifiedStruct
    {
    	public int Value {get; private set; }
    	
    	internal class ModifyingClass
    	{
    		public void ModifyValue()
    		{
    			ModifiedStruct s = new ModifiedStruct();
    			s.Value = 456;
    		}
    	}
    
    }
