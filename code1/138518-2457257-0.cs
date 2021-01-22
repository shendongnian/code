    int lastDepth = -1;
            int numUL = 0;
    
            StringBuilder output = new StringBuilder();
    
            foreach (DataRow row in ds.Tables[0].Rows)
            {
    
                int currentDepth = Convert.ToInt32(row["Depth"]);
    
                if (lastDepth < currentDepth)
                {
                    if (currentDepth == 0)
                    {
                        output.Append("<ul class=\"simpleTree\">");
                        output.AppendFormat("<li class=\"root\"><span><a href=\"#\" title=\"root\">root</a></span><ul><li class=\"open\" ><span><a href=\"#\" title={1}>{0}</a></span>", row["name"], row["id"]);
                    }
                    else
                    {
                        output.Append("<ul>");
                        if (currentDepth == 1)
                            output.AppendFormat("<li><span>{0}</span>", row["name"]);
                        else
                            output.AppendFormat("<li><span class=\"text\"><a href=\"#\" title={1}>{0}</a></span>", row["name"], row["id"]);
                    }
                    numUL++;
                }
                else if (lastDepth > currentDepth)
                {
                    //output.Append("</li></ul></li>");
                    output.Append("</li>");
                    for (int i = lastDepth; i > currentDepth; i--)
                    {
                        output.Append("</ul></li>");
                    }
    
                    if (currentDepth == 1)
                        output.AppendFormat("<li><span>{0}</span>", row["name"]);
                    else
                        output.AppendFormat("<li><span class=\"text\"><a href=\"#\" title={1}>{0}</a></span>", row["name"], row["id"]);
                    numUL--;
                }
                else if (lastDepth > -1)
                {
                    output.Append("</li>");
                    output.AppendFormat("<li><span class=\"text\"><a href=\"#\" title={1}>{0}</a></span>", row["name"], row["id"]);
                }
    
    
                lastDepth = currentDepth;
            }
    
            for (int i = 1; i <= numUL + 1; i++)
            {
                output.Append("</li></ul>");
            }
    
            myliteral.Text = output.ToString();
