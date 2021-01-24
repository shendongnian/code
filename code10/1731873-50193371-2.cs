    private void button1_Click(object sender, EventArgs e)
          {
             Brush brush1 = Brushes.Red;
             button1.BackColor = ((SolidBrush)brush1).Color;
             string getColor;
             getColor = button1.BackColor.ToString();
             MessageBox.Show($"Color of Button1  " + getColor);
    
          }
