    // in your Form_Init:
    
    Button [] buttons = new Button[10];    // create the array of button controls
    
    for(int i = 0; i < buttons.Length; i++)
    {
        
        buttons[i].Click += new EventHandler(btn_Click);
        buttons[i].Tag = i;               // Tag is an object, not a string as it was in VB6
        // a step often forgotten: add them to the form
        this.Controls.Add(buttons[i]);    // don't forget to give it a location and visibility
    }
    
    // the event:
    void btn_Click(object sender, EventArgs e)
    {
        // do your thing here, use the Tag as index:
        int index = (int) ((Button)sender).Tag;
        throw new NotImplementedException();
    }
