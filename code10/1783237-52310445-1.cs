    public void HandleItemEvent(ref SAPbouiCOM.ItemEvent pVal)
    { 
        if (pVal.BeforeAction == false && pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "Button1")
        {
            // You code here
        }
    }
