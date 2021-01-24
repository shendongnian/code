        private void button2_Click_1(object sender, EventArgs e)
        {
            int i = 0,j=0;
            string check1 = "",check2="";
            List<string> alreadySeen = new List<string>();
            for (i=0;i<dataGridView1.Rows.Count-1;i++)
            {
              check1 = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                j = i;
                for (j=j+1; j < dataGridView1.Rows.Count - 1; j++)
                {
                  check2 = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
                    if (check1==check2)
                    {
                        if (!alreadySeen.Contains(check1))
                            alreadySeen.Add(check1);
                    }
                }   
             }
            //Show duplicate value
            foreach (var x in alreadySeen)
            {
                MessageBox.Show(x);
            }
        }
