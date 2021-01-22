            if(Char.IsControl(e.KeyChar)!=true&&Char.IsNumber(e.KeyChar)==false)
            {
                e.Handled = true;
            }
           
        }
        //At key press event it will allows only the Characters and Controls.
       
