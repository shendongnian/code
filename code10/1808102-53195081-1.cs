    GameObject targetObj = GameObject.Find("Obj with Interface");
    IClicker clicker = targetObj.GetComponent<IClicker>();
    
    if (clicker != null)
        clicker.Click();
