    public ActionResult ExportToExcel()
            {
                ContactFormListViewModel viewModel = new ContactFormListViewModel();
                viewModel.ContactForm = contactFormRepository.GetAll();
    
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add(new DataColumn("Id", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Title", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
                dt.Columns.Add(new DataColumn("LastName", typeof(string)));
                dt.Columns.Add(new DataColumn("Address", typeof(string)));
                dt.Columns.Add(new DataColumn("City", typeof(string)));
                dt.Columns.Add(new DataColumn("State", typeof(string)));
                dt.Columns.Add(new DataColumn("Country", typeof(string)));
                dt.Columns.Add(new DataColumn("Zip", typeof(string)));
    
                foreach (var item in viewModel.ContactForm)
                {
                    dr = dt.NewRow();
    
                    dr[0] = item.ID;
                    dr[1] = item.Title;
                    dr[2] = item.FirstName;
                    dr[3] = item.LastName;
                    dr[4] = item.Address;
                    dr[5] = item.City;
                    dr[6] = item.State;
                    dr[7] = item.Country;
                    dr[8] = item.Zip;
    
                    dt.Rows.Add(dr);
                }
    
                var gv = new GridView();
              
                gv.DataSource = dt;
                gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();
    
                return View("Index");
            }
