    StringBuilder builder = new StringBuilder();
    builder.AppendLine("Form values:");
    foreach (string key in Request.Form.Keys) {
       builder.Append("  ").Append(key).Append(" = ").AppendLine(Request.Form[key]);
    }
    builder.AppendLine("QueryString values:");
    foreach (string keu in Request.QueryString.Keys) {
       builder.Append("  ").Append(key).Append(" = ").AppendLine(Request.QueryString[key]);
    }
    string values = builder.ToString();
