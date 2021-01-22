    namespace CustomControls
    {
     public class CustomGridView : GridView
        {
            private string _pageTotal;
    
            public string PageTotal
            {
                get { return _pageTotal; }
                set { _pageTotal = value; }
            }
    
            private string _grandTotal;
    
            public string GrandTotal
            {
                get { return _grandTotal; }
                set { _grandTotal = value; }
            }
    
            public CustomGridView()
            {
            }
    
            protected override void OnRowCreated(GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.SetRenderMethodDelegate(CreateFooter);
                }
                base.OnRowCreated(e);
            }
    
            private void CreateFooter(HtmlTextWriter PageOutput, Control FooterContainer)
            {
                StringBuilder footer = new StringBuilder();
                footer.Append("<td>" + this._pageTotal  +"</td>");
                footer.Append("</tr>");
                footer.Append("<tr>");
                footer.Append("<td>" + this._grandTotal + "</td>");
                footer.Append("</tr>");
                PageOutput.Write(footer.ToString());          
            }
        }
    }
