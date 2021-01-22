    //Hook both OnClick events to these!    
    private void OnButton1Click(object sender, EventArgs e) { BeenClicked(button1); }
    private void OnButton2Click(object sender, EventArgs e) { BeenClicked(button2); }
    private void BeenClicked(Button ClickedButton) 
    {
        if(ClickedButton.Text == "hi") Console.WriteLine("Hi to you too!"); 
    }
