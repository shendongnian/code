        DataTable dataTable = new DataTable();
        MailMessage message = new MailMessage();
        message.Subject = "Employee Access ";
        message.From = new MailAddress("avvv@gmail.com");
        var fromAddress = "avvv@gmail.com";
        const string fromPassword = "password";
        OleDbCommand cmd = null;
        string queryString = "select id,email,status from tableemail";
        using (OleDbConnection connection = new OleDbConnection("Provider = OraOLEDB.Oracle.1; Data Source = xe; Password = 654321; User ID = xpress; unicode = true"))
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
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
                MailAddress to = new MailAddress(dataRow[1].ToString());
                message.To.Add(to);
                message.Body = "The Employee id is 5  " + dataRow[0].ToString();
                smtp.Send(message);
            }
        }
