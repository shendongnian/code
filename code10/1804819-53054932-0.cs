    public void OnResultTest(object sender, EventArgs args) {         
        var lbl = sender as Label;
        if (lbl != null) 
        {
            TestModel obj = lbl.DataContext as TestModel;
            if (obj != null)
            {
                obj.ValueAnswer = "B";
            }
        }
    }
