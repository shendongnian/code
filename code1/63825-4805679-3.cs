    public int EditIndex 
            {
                get {return C_LV_ObjComposition.EditIndex;}
                set { C_LV_ObjComposition.EditIndex=value;}
            }
    
    public event EventHandler Editing;
    
     protected void ItemEditing(object sender, ListViewEditEventArgs e)
            {
                C_LV_ObjComposition.EditIndex = e.NewEditIndex;
                
                if (Editing != null)
                    Editing(this, e);
    
            }
