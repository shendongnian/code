    private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "ON")
            {
                panel_light.BackColor = Color.Yellow; //symbolizes light turned on
    
                button2.Text = "OFF";
            }
    
            else if (button2.Text == "OFF")
            {
                panel_light.BackColor = Color.Black; //symbolizes light turned off
    
                button2.Text = "ON";
            }
        }
