    protected void Button1_Click(object sender, EventArgs e) 
            { 
              //  SetRecursiveTextBoxAndLabels(PlaceHolder1); 
                CreateForm creater = new CreateForm(); 
                creater.Holder = PlaceHolder1; 
                creater.SetAccessForm(); 
     
                if (PlaceHolder1.Controls.Count > 0) 
                { 
                    foreach (Control item in PlaceHolder1.Controls) 
                    { 
                         if (item is TextBox)
                             TextBox t1=(TextBox)PlaceHolder1.FindControl(item.ID);
                    } 
                } 
            }
