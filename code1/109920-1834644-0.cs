    StringBuilder sb = new StringBuilder();
    foreach (string s in Delivery)
    {
        sb.Append(s);
        sb.Append(",");
    }
    sb.Remove(sb.Length-2,1).ToString();
