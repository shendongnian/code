            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            string fileName = Path.Combine(@"C:\Users\user\Desktop\SBS", FileUpload1.FileName);
            if (FileUpload1.HasFile)
            {
                var lines = File.ReadAllLines(fileName);
                try
                {
                    con.Open();
                    foreach (var line in lines)
                    {
                        var columns = line.Split('|');
                        SqlCommand myCommand = new SqlCommand("INSERT INTO SBSFile (SBSBranchCode, BranchName, FinYear, BrChallanNo, TransDate, MajorHead, ReceiptPayment, Amount, PlanNonPlan) " +
                                   $"Values('{columns[0]}', '{columns[1]}','{columns[2]}','{columns[3]}','{columns[4]}','{columns[5]}','{columns[6]}','{columns[7]}','{columns[8]}''{columns[9]}')");
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                }
            }
