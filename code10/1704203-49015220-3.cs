    private int originalPosition = 0;
    
    public void TogglePivotItem()
    {
        if (MyPivot.Items.Contains(HideablePivotItem))
        {
            //store the position of the item to be readded later
            originalPosition = MyPivot.Items.IndexOf(HideablePivotItem);
            MyPivot.Items.Remove(HideablePivotItem);
        }
        else
        {
            MyPivot.Items.Insert(originalPosition, HideablePivotItem);
        }            
    }
