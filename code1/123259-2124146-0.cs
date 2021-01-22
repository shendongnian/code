     private void button1_Click(object sender, EventArgs e)
        {
            string[] nine_labels = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            var labelarray= new Label[3,3];
            // putting labels into matrix form
            int c = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var lbl = new Label();
                    lbl.Text = nine_labels[c];
                    lbl.Top = i * 100;
                    lbl.Left = j * 100;
                    
                    labelarray[i, j] = lbl; 
                    c++;
                }
            }
            // adding labels to form
            foreach (var item in labelarray)
            {
                this.Controls.Add(item);
            }
            // test
            labelarray[1, 1].Text = "test";
        }
