    private void button1_Click(object sender, EventArgs e)
          {
             Brush brush1 = Brushes.Red;
         button1.BackColor = ((SolidBrush)brush1).Color;
         string getColor1;
         getColor1 = button1.BackColor.ToString();
         MessageBox.Show($"Color of Button1  " + getColor1);
         //Similarly store other button colors in a string
         string getColor2 = "Orange"; string getColor3 = "Blue"; 
         //Store these string value in a list 
         List<string> colors = new List<string>();
         colors.Add(getColor1);
         colors.Add(getColor2);
         colors.Add(getColor3);
         foreach (string color in colors) { MessageBox.Show(color); }
          }
