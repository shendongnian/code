     private void button1_Click(object sender, EventArgs e)
          {
             Brush brush = new SolidBrush(Color.Red);
             button1.BackColor = ((SolidBrush)brush).Color;
    
             string getColor;
             getColor = button1.BackColor.ToString();
             MessageBox.Show($"Color of Button1  " + getColor);
    
          }
