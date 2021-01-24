    private bool _hasWood;
    private GameObject _woodItem;
    public void clickWood()
    {
        //Check If The Player Has Gotten Wood Previously
        if(_hasWood == false)
        {
            _woodItem= Instantiate(wood_prefab) as GameObject;
            //Initial Displayed Name
            _woodItem.GetComponent<ButtonSetter>().setName("WOOD: ");
            //Starts with 0 Wood, set to 1
            _woodItem.GetComponent<ButtonSetter>().item_count += 1;
            _woodItem.transform.SetParent(GameObject.Find("Content").transform,false);
            //Got their first wood, should run else from now on
            _hasWood = true;
        }
        else
        {
            _woodItem.GetComponent<ButtonSetter>().item_count += 1;
        }
    }
