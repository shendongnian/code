    private void button1_Click(object sender, EventArgs e)
        {
            DataTable g = new DataTable();
            int rowCount = g.Rows.Count;
            Progress_tracker pForm = new Progress_tracker();
            pForm.Show();
            int rCount =0;
            foreach (DataRow r in g.Rows)
            {
                //do somethin
                pForm.progressBar1.Value = 100*rCount++ / rowCount;
            }
        }
