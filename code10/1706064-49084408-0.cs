    public void OnButtonClicked(object sender, EventArgs e)
    {
        // Assuming the List bound to the ListView contains "MyObject" objects,
        // for example List<MyObject>:
        var myObjectBoundToViewCell = (MyObject)((Button)sender).BindingContext;
        // and now use myObjectBoundToViewCell to get the text that is bound from the Entry
    }
