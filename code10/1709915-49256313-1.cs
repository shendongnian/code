         int number = 0;
         bool result = Int32.TryParse(textBox9.Text, out number);
         if (result)
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
