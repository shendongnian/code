    Here is an working example for ASP.NET (C#)
    
    -- (USER CONTROL)
    
    <head>
        <title></title>
        <link href="/UserControls/Accordion/Css/Accordion.css" rel="Stylesheet" type="text/css" media="all" />
    </head>
    
    <asp:Table ID="AccordionTable" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
        <asp:TableRow Width="100%" Height="200px">
            <%-- SLIDER 1 --%>
            <asp:TableCell CssClass="Border">
                <asp:Panel ID="Slide1Panel" runat="server" Style="display:block">
                    <p>Panel 1 content.</p>
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell CssClass="Border" Width="20px">
                <asp:LinkButton ID="LinkButton_1" runat="server" Text="Header 1" CssClass="VerticalText" OnClick="Slide_Click" />
            </asp:TableCell>
            <%-- SLIDER 2 --%>
            <asp:TableCell CssClass="Border">
                <asp:Panel ID="Slide2Panel" runat="server" Style="display:none">
                    <p>Panel 2 content.</p>
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell CssClass="Border" Width="20px">
                <asp:LinkButton ID="LinkButton_2" runat="server" Text="Header 2" CssClass="VerticalText" OnClick="Slide_Click" />
            </asp:TableCell>
            <%-- SLIDER 3 --%>
            <asp:TableCell CssClass="Border">
                <asp:Panel ID="Slide3Panel" runat="server" Style="display:none">
                    <p>Panel 3 content.</p>
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell CssClass="Border" Width="20px">
                <asp:LinkButton ID="LinkButton_3" runat="server" Text="Header 3" CssClass="VerticalText" OnClick="Slide_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    -- (CODE BEHIND)
    
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
    
    -- (STYLESHEET (BASIC))
    
    .VerticalText 
    { 
        writing-mode: tb-lr; 
        filter: flipV flipH; 
    }
    
    .Border
    {
        border: solid 1px Black;
    }
