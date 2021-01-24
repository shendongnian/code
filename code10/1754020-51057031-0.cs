     public void winner()
     {
    
          if (!int.TryParse(textBox1.Text, out int max))
          {
             MessageBox.Show("Dem numbers aren't numbers");
             return;
          }
    
          ...
