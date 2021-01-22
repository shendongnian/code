    System.Security.SecureString ss = new System.Security.SecureString();
    
    foreach (char c in password)
      ss.AppendChar(c);
    
    System.Diagnostics.Process proc = Process.Start(path, arguments, username, ss, domain);
 
