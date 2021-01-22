    StringCollection sc = scripter.Script(new Urn[] { myTable.Urn });
    foreach (string script in sc)
    {
        sb.AppendLine();
        sb.AppendLine("--create table");
        sb.Append(script + ";");
    }
