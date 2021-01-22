    public class EventReceiverTest : SPItemEventReceiver
    {
    	public override void ItemAdded(SPItemEventProperties properties)
    	{
    		properties.ListItem.CopyTo(
    			properties.WebUrl + "/Destination/" + properties.ListItem.File.Name);
    	}
    }
