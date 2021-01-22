            protected void CopyTable()
            {
                var clontable= new HtmlTable();
                var mytbl = form1.FindControl("mytable") as HtmlTable;
                if (mytbl != null)
                {
                    HtmlTableRow myrow;
                    HtmlTableCell mycell;
                    for (int i = 0; i < mytbl.Rows.Count - 1; i++)
                    {
                        myrow = new HtmlTableRow();
                        for (int j = 0; j < mytbl.Rows[i].Cells.Count - 1; j++)
                        {
                            mycell = new HtmlTableCell();
                            mycell.InnerHtml = mytbl.Rows[i].Cells[j].InnerHtml;
                            myrow.Cells.Add(mycell);
                        }
                        clontable.Rows.Add(myrow);
                    }
                    form1.Controls.Add(clontable);
                }
            }
