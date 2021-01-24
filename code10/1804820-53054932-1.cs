    public void OnResultTest(object sender, EventArgs args) {         
        var items =TestList.ItemsSource as List<TestModel>;
        if (items!= null) 
        {
            foreach (var item in items)
            {
                item.ValueAnswer = "B";
            }
        }
    }
