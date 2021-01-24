    // This class is responsible from carrying information + items belonging to a single group.
    public class SingleGroupCollection<N> : Collection<N>
    	{
            //
            // The property bag is where you carry the per-group data.
            // Like your grouped-by Manufacturer <"name", "G. Manufacturer">
            // You should expose methods so you could retrieve all of its 
            // keys-values and display the group-specific data in your UI.
    		Dictionary<string, string> PropertyBag;
    		public SingleGroupCollection()
    		{
                 // Classic .Add() / .Remove() methods should work since 
                 //   we inherit from a Collection.
    		}
    	}
