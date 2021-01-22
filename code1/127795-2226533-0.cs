    for (int i = 0; i < 7; i++) 
    { 
        
        Button newButton = new Button(); 
     
        newButton.Text = "Click me!"; 
     
        int iCopy = i; // There will be a new instance of this created each iteration
        newButton.Click += delegate(Object sender, EventArgs e) 
        { 
            MessageBox.Show("I am button number " + iCopy); 
        }; 
     
        this.Controls.Add(newButton); 
    }
 
