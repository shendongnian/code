                Response.Write("<table border=2>");
                Response.Write("<th>Id</th><th>Name</th>");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Response.Write("<tr>");
                        Response.Write("<td>");
                        Response.Write(row[0].ToString());
                        Response.Write("</td>");
                        Response.Write("<td>");
                        Response.Write(row[1].ToString());
                        Response.Write("</td>");
                    Response.Write("</tr>");
                }
                Response.Write("</table>");
