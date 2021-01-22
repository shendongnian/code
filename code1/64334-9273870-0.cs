                  protected void btnExcel_Click(object sender, ImageClickEventArgs e)
               {
                  Response.ClearContent();
                  Response.Buffer = true;
                  Response.AddHeader("content-disposition", string.Format("attachment; filename=      {0}", "Customers.xls"));
                  Response.ContentType = "application/ms-excel";
                 StringWriter sw = new StringWriter();
                 HtmlTextWriter htw = new HtmlTextWriter(sw);
                 gvdetails.AllowPaging = false;
                 gvdetails.DataBind();
                //Change the Header Row back to white color
                gvdetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
                //Applying stlye to gridview header cells
                for (int i = 0; i < gvdetails.HeaderRow.Cells.Count; i++)
              {
              gvdetails.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
              }
               int j = 1;
               //This loop is used to apply stlye to cells based on particular row
               foreach (GridViewRow gvrow in gvdetails.Rows)
               {
                 gvrow.BackColor = Color.White;
                 if (j <= gvdetails.Rows.Count)
               {
                if (j % 2 != 0)
          {
            for (int k = 0; k < gvrow.Cells.Count; k++)
              {
            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
              }
            }
           }
              j++;
            }
              gvdetails.RenderControl(htw);
                Response.Write(sw.ToString());
               Response.End();
              }
