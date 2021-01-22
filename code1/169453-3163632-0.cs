    for (int i = 0; i < DisplayNameNodes.Count; i++) 
    { 
     
        Button folderButton = new Button(); 
        folderButton.Width = 150; 
        folderButton.Height = 70; 
        folderButton.ForeColor = Color.Black; 
        folderButton.Text = DisplayNameNodes[i].InnerText; 
     
        //This will work and add button to your Form.
        this.Controls.Add(folderButton );
    
        //you can't get Control.Add on a type, it's not a static method. It only works on instances.
        //GUIWevbDav.Controls.Add
     
    }
 
 
