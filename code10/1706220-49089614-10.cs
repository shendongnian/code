    List<Button> tabletBtns = new List<Button>;
    for (int i = 1; i <= 150; i++)
    {
        var buttonName = string.Format("button{0}", i);
        var button = Controls[buttonName] as Button; // if the buttons are all on the main canvas or Controls.Find(buttonName, true).First() as Button if they are in some sort of containers (panels, borders, grouppboxes, etc)
        if (button != null)
        {
           tabletBtns.Add(button);
        }
    }
