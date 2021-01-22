    private void button1_Click(object sender, EventArgs e)
    {
      Runspace rs = RunspaceFactory.CreateRunspace();
      rs.Open();
      Pipeline pl = rs.CreatePipeline();
      pl.Commands.AddScript("get-wmiobject win32_share");
      
      StringBuilder sb = new StringBuilder();
      Collection<PSObject> list = pl.Invoke();
      rs.Close();
      foreach (PSObject obj in list)
      {
        string name = obj.Properties["Name"].Value as string;
        string path = obj.Properties["Path"].Value as string;
        string desc = obj.Properties["Description"].Value as string;
    
        sb.AppendLine(string.Format("{0}{1}{2}",name, path, desc));
      }
      // do something with the results...
    }
