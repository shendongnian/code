    int[,] counter = new int[16, 256];
    for (int i = 0; i < 1000000; i++)
    {
        var g = Guid.NewGuid();
        var bytes = g.ToByteArray();
        for (int idx = 0; idx < 16; idx++)
        {
            counter[idx, bytes[idx]]++;
        }
    }
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("x = [");
    for (int idx = 0; idx < 16; idx++)
    {
        for (int b = 0; b < 256; b++)
        {
            sb.Append(counter[idx, b]);
            if (idx != 255)
            {
                sb.Append(" ");
            }
        }
        if (idx != 15)
        {
            sb.AppendLine(";");
        }
    }
    sb.AppendLine("]");
    File.WriteAllText("plot.sce", sb.ToString());
