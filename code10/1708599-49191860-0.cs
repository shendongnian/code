    public class BusinessRuleBehaviourFactory : ISomefactory
    {
    	public ISomeBusinessRuleBehaviourDependingOnFlag Create(string flag)
    	{
    		if (flag == "something")
    			return new BlaImplementation();
    		else if (flag == "something else")
    			return new BoehImplementation();
    		
    		return new DefaultImplementation();
    	}
    }
