    public void InstantiateIn(System.Web.UI.Control container) 
    { 
        PlaceHolder ph = new PlaceHolder(); 
        SectionArgs e = new SectionArgs(); 
        ph.DataBinding += new EventHandler(ItemTemplate_DataBinding); 
        container.Controls.Add(ph); 
    } 
 
    static void ItemTemplate_DataBinding(object sender, EventArgs e) 
    { 
        PlaceHolder ph = (PlaceHolder)sender; 
    } 
