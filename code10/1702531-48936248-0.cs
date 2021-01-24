     private int cant = 0;
     private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
     {
            if (cant < 3)
            {
                //highlight
                cant++;
            }
            else if (cant < 6)
            {
                //not highlight
                cant++;
            }
            else
            {
                cant = 0;
            }
        }
