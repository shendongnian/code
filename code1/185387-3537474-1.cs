    //Hook both OnClick events to this!
    private void OnButtonClick(object sender, EventArgs e) 
    { 
        ClickedButton = (Button)sender; 
        if(ClickedButton.Text == "hi") Console.WriteLine("Hi to you too!"); 
    }
