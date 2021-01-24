    public ActionResult DownloadFile(string filename)
        {
            if (Path.GetExtension(filename) == ".pdf")
            {
                string fullPath = Path.Combine(Server.MapPath("~/Images/ArticleOfAssociations"), filename);
                return File(fullPath, "ArticleOfAssociations/pdf");
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }
        }
