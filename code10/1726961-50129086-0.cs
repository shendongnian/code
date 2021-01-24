    void Button1Clicked(object sender, EventArgs e)
    {
    disableAllButtons();
    // ... do something first ...
    page1.IsVisible = true;
    Console.WriteLine("Button 1 Clicked!");
    }
    void Button2Clicked(object sender, EventArgs e)
    {
    disableAllButtons();
    // ... do something first ...
    page2.IsVisible = true;
    Console.WriteLine("Button 2 Clicked!");
    }
    void Button3Clicked(object sender, EventArgs e)
    {
    disableAllButtons();
    // ... do something first ...
    page3.IsVisible = true;
    Console.WriteLine("Button 3 Clicked!");
    }
    void Back1Clicked(object sender, EventArgs e)
    {
    enableAllButtons();
    }
    void Back2Clicked(object sender, EventArgs e)
    {
    enableAllButtons();
    }
    void Back3Clicked(object sender, EventArgs e)
    {
    enableAllButtons();
    }
    void disableAllButtons()
    {
    button1.IsEnabled = false;
    button2.IsEnabled = false;
    button3.IsEnabled = false;
    disableAllPages();
    }
    void enableAllButtons()
    {
    button1.IsEnabled = true;
    button2.IsEnabled = true;
    button3.IsEnabled = true;
    disableAllPages();
    }
    void disableAllPages()
    {
    page1.IsVisible = false;
    page2.IsVisible = false;
    page3.IsVisible = false;
    }
