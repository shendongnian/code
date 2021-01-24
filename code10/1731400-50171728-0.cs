    int[] values = new int[6];
            values[0] = 2;
            values[1] = 9;
            values[2] = 5;
            values[3] = 15;
            values[4] = 8;
            values[5] = 25;
            bool status = values.Contains(Convert.ToInt16(txtValue.Text));//I want to retrieve it from txtbox  
            lblindex.Text = status.ToString();
            int indexi =Array.IndexOf(values,Convert.ToInt16(txtValue.Text)); //same is true for this method aswell.         
            lblindex.Text = indexi.ToString();
            foreach (int item in values)
            {
                listBox1.Items.Add(item);
            }
