    public class ItemsWrapper
    {
      private Items _items;
      private MAPIFolder _folder;
      public ItemsWrapper(MAPIFolder folder)
      {
        _folder = folder;
        _items = folder.Items;
        _items.ItemAdd += Item_Add;
      }
      private Items_Add(object item)
      {
        MessageBox.Show($"New item in folder '{folder.Name}' ");
      }
    }
    
    ...
    //global/class variable that will hold the wrappers
    List<ItemsWrapper> allWrappers = new List<ItemsWrapper>();
    foreach (MAPIFolder folder in FoldersThatYouWantToProcess)
    {
      ItemsWrapper wrapper = new ItemsWrapper(folder);
      allWrappers.Add(wrapper);
    } 
