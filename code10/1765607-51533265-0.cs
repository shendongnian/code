    GameObject o = null;
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            o = Instantiate(obj) as GameObject;
            o.transform.SetParent(pos_obj);
            o.transform.localScale = Vector3.one;
            o.transform.name = "chips " + i;
    
            o.transform.localPosition = new Vector3(0, 0, 0);
            NGUITools.SetActive(o, true);
            
            UIEventListener.Get(o).onClick += TestClickEvent;
            UIGridReposition(UIGrid.Sorting.Vertical, true);
        }
    }
    
    void TestClickEvent(GameObject sender) 
    { 
        Debug.Log("Clicked: " + sender.name); 
    }
