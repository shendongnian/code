    string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
            string FilePath = Server.MapPath("~/uploads/Endorsement/" + FileName);
            uploadFile.SaveAs(FilePath);
            StreamReader streamreader = new StreamReader(FilePath);
            char[] delimiter = new char[] { '\t' };
            string[] columnheaders = streamreader.ReadLine().Split(delimiter);
            foreach (string columnheader in columnheaders)
            {
                if (columnheader.Contains("Procedure Code") || columnheader.Contains("Waiting Days") || columnheader.Contains("Group ID"))
                {
                }
                else
                {
                    if ((File.Exists(FilePath)))
                    {
                        lblError.Text = "Invalid Columns Provided";
                    }
                }
            }
