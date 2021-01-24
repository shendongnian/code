    openFileDialog1.ShowDialog();
    string filename = openFileDialog1.FileName;
    string data;
    //using a string builder to concat strings is much more efficient
    StringBuilder sbLog = new StringBuilder();
    StringBuilder sbError = new StringBuilder();
    
    using (StreamReader file = new StreamReader(filename))
    {
       while ((data = file.ReadLine()) != null)
       {
          if (data.Split('"')[2].Trim().StartsWith("404"))
          {
             sbLog.Append(data + Environment.NewLine);
             sbError.Append(data.Split('"')[2].Trim().Substring(0, 3) + Environment.NewLine);
          }
       }                
    }
    
    txtLog.Text = sbLog.ToString();
    txtError.Text += sbError.ToString();
