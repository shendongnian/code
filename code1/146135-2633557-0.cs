            StringBuilder sb = new StringBuilder();
            int pos = 0;
            Regex exp = new Regex(@"\[(.+)\s*\\(.+)\]");
            foreach (Match m in exp.Matches(text))
            {
                sb.Append(text, pos, m.Index - pos);
                pos = m.Index + m.Length;
                Uri tmp;
                if(Uri .TryCreate(m.Groups[2], UriKind.Absolute, out tmp))
                {
                    sb.AppendFormat("<a href=\"{0}\" target=\"_blank\">{1}</a>",
                        System.Web.HttpUtility.HtmlAttributeEncode(tmp.AbsoluteUri),
                        System.Web.HttpUtility.HtmlEncode(m.Groups[1])
                        );
                }
            }
            sb.Append(text, pos, text.Length - pos);
