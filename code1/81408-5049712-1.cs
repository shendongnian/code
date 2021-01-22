     private void btnSearch_Click(object sender, EventArgs e)
    {
    String searchBy = cmbSearchBy.Text.ToString();
    String searchFor = txtSearchFor.Text.Trim();
    
    var List3 = (from row in JobTitleDB.jobList
                             where (row.JID.ToString()+row.JobTitleName.ToString().ToLower()).Contains(searchFor.ToLower())
                             select row).ToList();
    if (searchBy == "All")
                {
                    dgJobTitles.DataSource = null;
                    //dgJobTitles.DataSource = List1;
                    //dgJobTitles.DataSource = List2;
                    //dgJobTitles.DataSource = List1.Concat(List2);
                    //dgJobTitles.DataSource = List1.Union(List2);
                    dgJobTitles.DataSource = List3;
                    //dgJobTitles.DataSource=List1.AddRange(List2);
                }
    }
