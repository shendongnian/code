    protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            protected void Slide_Click(object sender, EventArgs e)
            {
                ResetSlides();
    
                LinkButton linkButton = (LinkButton)sender;
                
                char[] separator = new char[] { '_' };
                string[] trigger = linkButton.ID.Split(separator);
    
                foreach (TableRow tblRow in AccordionTable.Rows)
                {
                    int i = 1;
                    foreach (TableCell tblCell in tblRow.Cells)
                    {
                        if (i % 2 == 0)
                        {
                            // Dont touch our LinkButtons (!)
                        }
                        else
                        {
                            Panel slidePanel = (Panel)FindControl("Slide" + trigger[1] + "Panel");
                            if (slidePanel != null)
                            {
                                slidePanel.Style.Add("display", "block");
                                tblCell.Style.Remove("display");
                                tblCell.Style.Add("display", "block");
                            }
                        }
                        i++;
                    }
                }
            }
    
            protected void ResetSlides()
            {
                foreach (TableRow tblRow in AccordionTable.Rows)
                {
                    int i = 1;
                    foreach (TableCell tblCell in tblRow.Cells)
                    {
                        Panel slidePanel = (Panel)FindControl("Slide" + i + "Panel");
                        if (slidePanel != null)
                        {
                            tblCell.Style.Remove("display");
                            slidePanel.Style.Add("display", "none");
                        }
                        if (i % 2 == 0)
                        {
                            // Dont resize LinkButtons (!)
                        }
                        else
                        {
                            tblCell.Style.Remove("display");
                            tblCell.Style.Add("display", "none");
                        }
                        i++;
                    }
                }
            }
    
