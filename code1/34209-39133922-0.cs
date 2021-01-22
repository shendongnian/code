    private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          List<Form> fm = this.MdiChildren.ToList();
            if(fm!=null && fm.Count>0)
            {
                foreach(Form lfm in fm)
                {
                    lfm.Close();
                }
            }
        }
