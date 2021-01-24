    /*
        This class will hold all of the data that you're tranferring across.
        Depending on the grouping type - which I've imagined to be an enum, 
        you can set to be only 1 group / vs multiple groups,
        fill the class as you see fit with the information that you've retrieved from the DB.
     */
    public class GroupedCollection<N> : Collection<SingleGroupCollection<N>>
    	{
    		public GroupedCollection()
    		{
    			// default
    		}
    
    		public GroupedCollection(GroupingType[] type)
    		{
    			// set types
    			// set collection
    		}
    	}
