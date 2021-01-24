          protected void Button1_Click(object sender, EventArgs e)
        {
            
                string strFullPath = Server.MapPath("~/Content/Sample Contact.xlsx");
          
            string attachment = "attachment; filename=Sample_Contact.xlsx";
            Response.ClearContent();
           Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", attachment);
            Response.BinaryWrite(File.ReadAllBytes(strFullPath));
           
            Response.End();
        }
