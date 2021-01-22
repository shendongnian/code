    private void button2_Click(object sender, EventArgs e)
    {
      StringBuilder sb = new StringBuilder();
      string test = "The rain in spain falls \t mainly on the plain";
      sb.AppendLine(test);
      UTF8Encoding enc = new UTF8Encoding();
      byte[] b = enc.GetBytes(test);
      string cvtd = Convert.ToBase64String(b);
      sb.AppendLine(cvtd);
      byte[] c = Convert.FromBase64String(cvtd);
      string backAgain = enc.GetString(c);
      sb.AppendLine(backAgain);
      MessageBox.Show(sb.ToString());
    }
