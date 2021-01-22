     using (SecureString ss = new SecureString())
     {
        foreach (char c in Password)
          ss.AppendChar(c);
        thisPipeline.Commands[0].Parameters.Add("Password", ss);
     }
