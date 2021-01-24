    public RelayCommand<string> RadioButtonCommand { get; }
    public MyClassConstructorViewModel()
    {
        RadioButtonCommand = new RelayCommand<string>(radioButtonClick);
    }
    private void radioButtonClick(string name)
    {
        if(name == "radioButton1")
            Console.WriteLine("Radio Button 1 Clicked...");
        else if(name == "radioButton2")
            Console.WriteLine("Radio Button 2 Clicked...");
    }
        
