        private void button1_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dgv1.Rows.Count; i++)
            {
                list.Add(Convert.ToString(dgv1.Rows[i].Cells[1].Value));
            }
            //restore dgv1
            UpdateDgv1();
            Form2 f = new Form2();
            f.ShowDialog();
            //clear list with old values or comment it
            //if you want to save history of user inputs
            list.Clear();
        }
