public class RowClickableGridView : GridView
    {
        public Style HoverRowStyle
        {
            get { return ViewState["HoverRowStyle"] as Style; }
            set { ViewState["HoverRowStyle"] = value; }
        }
        public bool EnableRowClickSelection
        {
            get { return ViewState["EnableRowClickSelection"] as bool? ?? true; }
            set { ViewState["EnableRowClickSelection"] = value; }
        }
        public string RowClickCommand
        {
            get { return ViewState["RowClickCommand"] as string ?? "Select"; }
            set { ViewState["RowClickCommand"] = value; }
        }
        public string RowToolTip
        {
            get
            {
                if (!RowToolTipSet) return string.Format("Click to {0} row", RowClickCommand.ToLowerInvariant());
                return ViewState["RowToolTip"] as string;
            }
            set
            {
                ViewState["RowToolTip"] = value;
                RowToolTipSet = true;
            }
        }
        private bool RowToolTipSet
        {
            get { return ViewState["RowToolTipSet"] as bool? ?? false; }
            set { ViewState["RowToolTipSet"] = value; }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            foreach (GridViewRow row in Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;
                if (EnableRowClickSelection && row.RowIndex != SelectedIndex && row.RowIndex != EditIndex)
                {
                    if (string.IsNullOrEmpty(row.ToolTip)) row.ToolTip = RowToolTip;
                    row.Style[HtmlTextWriterStyle.Cursor] = "pointer";
                    PostBackOptions postBackOptions = new PostBackOptions(this,
                                                                          string.Format("{0}${1}",
                                                                                        RowClickCommand,
                                                                                        row.RowIndex));
                    postBackOptions.PerformValidation = true;
                    row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(postBackOptions);
                    foreach (TableCell cell in row.Cells)
                    {
                        foreach (Control control in cell.Controls)
                        {
                            const string clientClick = "event.cancelBubble = true;{0}";
                            WebControl webControl = control as WebControl;
                            if (webControl == null) continue;
                            webControl.Style[HtmlTextWriterStyle.Cursor] = "Auto";
                            Button button = webControl as Button;
                            if (button != null)
                            {
                                button.OnClientClick = string.Format(clientClick, button.OnClientClick);
                                continue;
                            }
                            ImageButton imageButton = webControl as ImageButton;
                            if (imageButton != null)
                            {
                                imageButton.OnClientClick = string.Format(clientClick, imageButton.OnClientClick);
                                continue;
                            }
                            LinkButton linkButton = webControl as LinkButton;
                            if (linkButton != null)
                            {
                                linkButton.OnClientClick = string.Format(clientClick, linkButton.OnClientClick);
                                continue;
                            }
                            webControl.Attributes["onclick"] = string.Format(clientClick, string.Empty);
                        }
                    }
                }
                if (HoverRowStyle == null) continue;
                if (row.RowIndex != SelectedIndex && row.RowIndex != EditIndex)
                {
                    row.Attributes["onmouseover"] = string.Format("this.className='{0}';", HoverRowStyle.CssClass);
                    row.Attributes["onmouseout"] = string.Format("this.className='{0}';",
                                                                 row.RowIndex%2 == 0
                                                                     ? RowStyle.CssClass
                                                                     : AlternatingRowStyle.CssClass);
                }
                else
                {
                    row.Attributes.Remove("onmouseover");
                    row.Attributes.Remove("onmouseout");
                }
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            foreach (GridViewRow row in Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation(row.ClientID);
                }
            }
        }
    }
