    public string BuildOrdersCsv(List<Order> orders)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Order o in orders)
        {
            Append(sb, o.ID, o.Created);
            for (int i = 0; i < 2; i++)
            {
                if (i < o.Items.Count)
                    Append(sb, o.Items[i].Sku, o.Items[i].Quantity);
                else
                    Append(sb, "", "");
            }
            sb.AppendLine("\"N\"");
            for (int i = 2; i < o.Items.Count; i++)
            {
                Append(sb, "", "", o.Items[i].Sku, o.Items[i].Quantity, "", "");
                sb.AppendLine("\"Y\"");
            }
        }
        return sb.ToString();
    }
    private void Append(StringBuilder sb, params object[] items)
    {
        foreach (object item in items)
        {
            sb.Append("\"").Append(item).Append("\",");
        }
    }
