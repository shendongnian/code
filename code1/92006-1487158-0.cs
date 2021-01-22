    int dreamX[];
    private void Form1_Load(object sender, EventArgs e)
            { 
             sumX();
            }
     private void sumX()
            {
                    dreamX =( from Control control in Controls                  
                             where control.GetType() == typeof(TextBox) &&
                                   control.Name.StartsWith("box")
                             select Convert.ToInt32(((TextBox)control).Text))
                                           .ToArray();             
            }
