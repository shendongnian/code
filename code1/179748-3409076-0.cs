    byte[] bytes = File.ReadAllBytes(Assembly.GetExecutingAssembly().Location);
    
    // this can get large, we know how large, so allocate early and try to be correct
    // note: a newline is two bytes
    StringBuilder sb = new StringBuilder(bytes.Length * 3 + (bytes.Length / 16) * 4);
    
    for (int i = 0; i < bytes.Length; i++)
    {
        sb.AppendFormat("{0:X2} ", bytes[i]);
        if (i % 8 == 0 && i % 16 != 0)
            sb.Append("  ");
        if (i % 16 == 0)
            sb.Append("\n");
    
    }
