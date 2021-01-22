     I think soemthing like this would work:
   
     void IterateControls(Control parent)
             {
                        foreach (Control c in parent.Controls)
                        {
                            if (c is CheckBox)
                            {
                              keepList.Add(c)
                            }
                                
                            if (c.Controls.Count > 0)
                            {          
                              IterateThroughChildren(c);          
                            }
                        }
              }
