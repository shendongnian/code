    initControlsRecursive(ControlCollection coll)
     { 
        foreach (Control c in coll)  
         {  
           c.MouseClick += (sender, e) => {/* handle the click here  */});  
           initControlsRecursive(c.Controls);
         }
     }
    /* ... */
    initControlsRecursive(Form.Controls);
