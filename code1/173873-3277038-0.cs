    var sb = new StringBuilder();
    sb.AppendLine("function fooBar() {");
    sp.AppendLine(String.Join(Environment.NewLine, blah));
    sp.AppendLine("}");
    page.RegisterClientScript(page.GetType(), sb.ToString());
