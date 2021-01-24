    public void updateInventory()
    {
        int index = 0;
    
        if (Buttonlist != null)
        {
            foreach (GameObject ob in Buttonlist)
            {
                DestroyImmediate(ob, false);
            }
            Buttonlist.Clear();
            ButtonId = 0;
            Position = new Vector3(0, 0, 0);
        }
    
        Canvas.ForceUpdateCanvases();
        foreach (Gun item in gunScript.secInventory)
        {
            GameObject buttonObj = SetButtonItem(ButtonId.ToString(),item.Name,Position);
    		Buttonlist.Add(buttonObj);
    		Position.y -= 49;
    		ButtonId++;
        }
    }
    
    private GameObject SetButtonItem(string ButtonId,string itemName,Vector3 pos)
    {
    	GameObject temp = Instantiate(getButton) as GameObject;
    	
    	temp.transform.position = getButton.transform.position + pos;
    	temp.GetComponentInChildren<Text>().text = itemName;
    	temp.name = ButtonId;
    	temp.AddComponent<Button_Clicked>();
    	temp.transform.parent = Content;
    	temp.SetActive(true);
    	
    	return temp;
    }
