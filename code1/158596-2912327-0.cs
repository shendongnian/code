      protected void databound(object sender, EventArgs e)
      {
         if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
         {
            var control = DetailsView1.Rows[0].Cells[1].FindControl("chkboxTest");
            if (control != null)
            {
               // Write some JS...
            }
         }
      }
