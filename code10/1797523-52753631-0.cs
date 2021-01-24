    public Button AddButton(int num, Action actionToPerform)
    {
        var btnX = new Button { Content = "btn" + num };
        btnX.Click += (sender, args) => { actionToPerform(); }
        return btnX; 
    }
