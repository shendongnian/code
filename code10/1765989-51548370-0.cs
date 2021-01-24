    Button1ViewModel ActiveItem_1 = null;
    Button2ViewModel ActiveItem_2 = null;
    Button3ViewModel ActiveItem_3 = null;
    Button4ViewModel ActiveItem_4 = null;
    public void Button1()
    {
        if (ActiveItem_1 == null)
            ActiveItem_1 = new Button1ViewModel();
        if (ActiveItem_2 != null)
        {
            ActiveItem_2.TryClose();
            ActiveItem_2 = null;
        }
        if (ActiveItem_3 != null)
        {
            ActiveItem_3.TryClose();
            ActiveItem_3 = null;
        }
        if (ActiveItem_4 != null)
        {
            ActiveItem_4.TryClose()
            ActiveItem4 = null;
        }
    }
