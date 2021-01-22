                int keyCount = results.Keys.Count;
                writer.WriteLine("<table border='1'>");
                writer.WriteLine("<tr>");
                for (int i = 0; i < keyCount; i++)
                {
                    writer.WriteLine("<th>" + results.Keys.ToArray()[i] + "</th>");
                }
                writer.WriteLine("</tr>");
                int valueCount = results.Values.ToArray()[0].Count;
                for (int j = 0; j < valueCount; j++)
                {
                    writer.WriteLine("<tr>");
                    for (int i = 0; i < keyCount; i++)
                    {
                        writer.WriteLine("<td>" + results.Values.ToArray()[i].ToArray()[j] + "</td>");
                    }
                    writer.WriteLine("</tr>");
                }
                writer.WriteLine("</table>");
