    public class EventReceiverTest : SPItemEventReceiver
    {
    	public override void ItemAdded(SPItemEventProperties properties)
    	{
    		SPFile sourceFile = properties.ListItem.File;
    		SPFile destFile;
    
    		// Copy file from source library to destination
    		using (Stream stream = sourceFile.OpenBinaryStream())
    		{
    			SPDocumentLibrary destLib =
    				(SPDocumentLibrary) properties.ListItem.Web.Lists["Destination"];
    			destFile = destLib.RootFolder.Files.Add(sourceFile.Name, stream);
    			stream.Close();
    		}
    
    		// Update item properties
    		SPListItem destItem = destFile.Item;
    		SPListItem sourceItem = sourceFile.Item;
    		destItem["Title"] = sourceItem["Title"];
    		//...
    		//... destItem["FieldX"] = sourceItem["FieldX"];
    		//...
    		destItem.UpdateOverwriteVersion();
    	}
    }
