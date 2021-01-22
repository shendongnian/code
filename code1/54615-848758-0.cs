                //Use these headers to display a saves as / download
                //Response.ContentType = "application/octet-stream";
                //Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", Path.GetFileName(Path)));
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", String.Format("inline; filename={0}.pdf", Path.GetFileName(Path)));
                Response.WriteFile(path);
                Response.Flush();
                Response.End();
