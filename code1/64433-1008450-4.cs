    StringBuilder sb = new StringBuilder();
    foreach (var group in query)
    {
        int count = 0;
        foreach (var item in group)
        {
            if (count++ == 0)
            {
                sb.Append(item.PO);
            }
            sb.Append(", ").Append(item.Sku).Append(", ").Append(item.Qty);
        }
        while (count++ < 5)
        {
            sb.Append(", , ");
        }
        sb.Append(Environment.NewLine);
    }
    string csv = sb.ToString();
