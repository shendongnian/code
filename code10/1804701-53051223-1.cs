    var smtp = new System.Net.Mail.SmtpClient();
           {
               smtp.Host = "smtp.gmail.com";
               smtp.EnableSsl = true;
               smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
               smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
               smtp.Timeout = 20000;
           }
    
           OleDbCommand cmd = null;
           OleDbCommand cmd2 = null;
           string queryString = "select id,email,credit from emailinfo";
           using (OleDbConnection connection = new OleDbConnection("Provider = OraOLEDB.Oracle.1; Data Source = orcl; Password=bdipf;User ID = human; unicode=true"))
           {
               OleDbCommand command = new OleDbCommand(queryString, connection);
               connection.Open();
               cmd = new OleDbCommand(queryString);
               cmd.Connection = connection;
               OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
               adapter.Fill(dataTable);
               adapter.Dispose();
           }
           foreach (DataRow dataRow in dataTable.Rows)
           {
    
    MailMessage message = new MailMessage();
           message.Subject = "Employee Access ";
           message.From = new MailAddress("xyz@gmail.com");
           var fromAddress = "zxy@gmail.com";
           const string fromPassword="password";
                   message.To.Add(new MailAddress(dataRow[1].ToString()););
                 message.Body = "Dear User your credit value: " + dataRow[2].ToString();
                   smtp.Send(message);continue
               }
           }
