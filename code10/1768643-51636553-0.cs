    private void button1_Click(object sender, EventArgs e)
        {
            LinqTestDataContext ctx = new LinqTestDataContext("Data Source=.;Initial Catalog=valveManagement2018;Integrated Security=True");
            var data = ctx.valves.AsQueryable();
    
            if (rbvalveStreet.Checked)
            {
                if (!string.IsNullOrEmpty(valveStreet.Text))
                {
                   data = data.Where(p => p.valveStreet.Contains(valveStreet.Text));
                }
            }
            if (rbtypeId.Checked)
            {
                   data = data.Where(p => p.typeId == cbTypeId.selectedIndex);
            }
    
            var qryFinal = data.Select( p => new { p.valveId, p.aTId, p.typeId,p.valveStreet });
    
            dgv.DataSource = qryFinal.ToList();
        }
