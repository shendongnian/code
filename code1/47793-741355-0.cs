    class ListBox
    {
      Bind(Items)
      {
        foreach(var item in Items)
        {
          DataTemplate Template = LoadTemplateForItem(item.GetType()); // this is where your template get loaded
          Template.Bind(item); //this is where your template gets bound
        }
      }
    }
