        private void button1_Click(object sender, EventArgs e)
        {
            List<Color> lstColour = new List<Color>();
            foreach (Control c in groupBox1.Controls)
                lstColour.Add(c.ForeColor);
            groupBox1.ForeColor = Color.Red; //the colour you prefer for the text
            int index = 0;
            foreach (Control c in groupBox1.Controls)
            {
                c.ForeColor = lstColour[index];
                index++;
            }
        }
