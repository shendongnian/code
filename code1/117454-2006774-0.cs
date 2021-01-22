    protected void MoveEmploymentUp(object sender, ImageClickEventArgs e)
    {
        ICVDao cvdao = DaoFactory.GetCVDao();        
        CV currentCv = cvdao.GetById(Int32.Parse(Request.Params["CVID"]), false);
        IEmployerDao eDao = DaoFactory.GetEmployerDao();
        ImageButton i = (ImageButton)sender;
        /*
         * if chap above
         * Swap numbers with chap above
         * if not
         * dont swap
         */
        GridViewRow g = (GridViewRow)i.Parent.Parent;
        
        Employer emp = (Employer)g.DataItem;
        EmploymentDataGrid.SelectedIndex = g.RowIndex;
        Employer movingEmployment = eDao.GetById(int.Parse(EmploymentDataGrid.SelectedDataKey.Value.ToString()), false);
        
        Employer otherEmployment = new Employer();
        if (movingEmployment.Position != 1 && currentCv.Employment.Count > 1)
        {
            foreach (Employer em in currentCv.Employment)
            {
                if (em.Position == movingEmployment.Position - 1)
                    otherEmployment = em;
            }
            movingEmployment.Position -= 1;
            otherEmployment.Position += 1;
            eDao.SaveOrUpdate(movingEmployment);
            eDao.CommitChanges();
            eDao.SaveOrUpdate(otherEmployment);
            eDao.CommitChanges();
            EmploymentGridBind();
            //InstructionsLabel.Text = "Mover Dates:" +movingEmployment.Dates+ " ID:" + movingEmployment.EmployerId + " Position:" + movingEmployment.Position +
            //    "<br />Other Dates:" + otherEmployment.Dates + " ID:" + otherEmployment.EmployerId + " Position:" + otherEmployment.Position;
        }
        
    }
