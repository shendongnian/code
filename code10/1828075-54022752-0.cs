    public void LoadStates()
            {
    
                try
                {
                    TESTEntities db = new TESTEntities();
    
                    // cmbProvince.Text = "";
    
                    var states = (from u in db.States
    
    
                                    select new
                                    {
                                        u.StateId,
    
                                        u.StateName,
                                        u.Cityies.Count
                                    }).ToList();
    
    
                    dgvStates.DataSource = states;
                    dgvStates.Columns[0].Visible = false;
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
    
            }
