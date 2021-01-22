    var storedFile = db.documents.Where(a => a.document_id.ToString() == dropAttachments.SelectedValue).Single();
          
                Response.Clear();
                Response.ContentType = "application/x-unknown";
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + storedFile.original_name + "\"");
                Response.BinaryWrite(storedFile.file_data.ToArray());
                Response.End();
