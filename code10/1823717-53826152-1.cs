    IInteractable item = itemhit.collider.gameobject.GetComponent<IInteractable>();            
    if (item != null)
    {
    //Then you have found an item that needs to be picked up.
      string name = item.GetItemInfo().identifier;
    
    }
