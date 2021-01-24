    private Button CreateFrom(string script)
    {
        var values = script.Split(",");
        if (values.Length != 4)
        {
            throw new ArgumentException("Not all values provided", nameof(script));
        }
        if (int.TryParse(values[1], out int x) == false)
        {
            throw new ArgumentException("X value is invalid");
        }     
        if (int.TryParse(values[2], out int y) == false)
        {
            throw new ArgumentException("Y value is invalid");
        }    
        if (string.isNullOrEmpty(values[3]))
        {
            throw new ArgumentException("Title is empty");
        }    
        var button = new Button 
        { 
            Text = values[3],
            Location = new System.Drawing.Point(x, y)
        };
        return button;        
    }
    private void DoTheButton()
    {
        var button = CreateFrom(insertedText);
        Controls.Add(button);
    }
   
