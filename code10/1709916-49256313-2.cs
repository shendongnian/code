         if (Int32.TryParse(textBox9.Text, out int number))
         {
            if (number > 17) 
              {
                  groupBox1.Enabled = false;
             }
            else
             {
                groupBox1.Enabled = true;
             }       
         }
