            public static void WriteCsv(string[] headers, IEnumerable<string[]> data, string filename)
            {
                if (data == null) throw new ArgumentNullException("data");
                if (string.IsNullOrEmpty(filename)) filename = "export.csv";
                HttpResponse resp = System.Web.HttpContext.Current.Response;
                resp.Clear();
                // remove this line if you don't want to prompt the user to save the file
                resp.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                // if not saving, try: "application/ms-excel"
                resp.ContentType = "text/csv";
                string csv = GetCsv(headers, data);
                byte[] buffer = resp.ContentEncoding.GetBytes(csv);
                resp.AddHeader("Content-Length", buffer.Length.ToString());
                resp.BinaryWrite(buffer);
                resp.End();
            }
            static void WriteRow(string[] row, StringBuilder destination)
            {
                if (row == null) return;
                int fields = row.Length;
                for (int i = 0; i < fields; i++)
                {
                    string field = row[i];
                    if (i > 0)
                    {
                        destination.Append(',');
                    }
                    if (string.IsNullOrEmpty(field)) continue; // empty field
                    bool quote = false;
                    if (field.Contains("\""))
                    {
                        // if contains quotes, then needs quoting and escaping
                        quote = true;
                        field = field.Replace("\"", "\"\"");
                    }
                    else
                    {
                        // commas, line-breaks, and leading-trailing space also require quoting
                        if (field.Contains(",") || field.Contains("\n") || field.Contains("\r")
                            || field.StartsWith(" ") || field.EndsWith(" "))
                        {
                            quote = true;
                        }
                    }
                    if (quote)
                    {
                        destination.Append('\"');
                        destination.Append(field);
                        destination.Append('\"');
                    }
                    else
                    {
                        destination.Append(field);
                    }
                }
                destination.AppendLine();
            }
            static string GetCsv(string[] headers, IEnumerable<string[]> data)
            {
                StringBuilder sb = new StringBuilder();
                if (data == null) throw new ArgumentNullException("data");
                WriteRow(headers, sb);
                foreach (string[] row in data)
                {
                    WriteRow(row, sb);
                }
                return sb.ToString();
            }
