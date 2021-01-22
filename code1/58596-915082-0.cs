        var client = new Client(Int32.Parse(Session["uid"].ToString()));
        var genReceipt = new Process();
        genReceipt.StartInfo.FileName = "Chitanta_unit.exe";
        genReceipt.StartInfo.WorkingDirectory = @"C:\chitanta_unit\";
        genReceipt.StartInfo.Arguments = client.ClientID.ToString();
        genReceipt.Start();
        genReceipt.WaitForExit();
        if (genReceipt.ExitCode == 0)
        {
            Response.Redirect("~/subscriber/ch/" + client.GetChitantaFilename());
        }
        genReceipt.Close();
