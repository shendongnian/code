    public extension MyPersonExtension extends Person
    {
    	public int FingersCount
    	{
            get 
            {
               // this is the instance of Person
    		   return this.Fingers.Count(); 
            }
    	}
    }
    var person = new Person();
    var fingerCount = person.FingersCount;
