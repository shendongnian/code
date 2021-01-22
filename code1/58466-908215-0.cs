            StringBuilder outString = new StringBuilder();
            StringWriter outWriter = new StringWriter(outString);
            HtmlTextWriter htmlText = new HtmlTextWriter(outWriter);
            System.Web.UI.WebControls.Label lbl1 = new System.Web.UI.WebControls.Label();
            lbl1.Text = "This is just a test!";
            lbl1.ToolTip = "Really";
            lbl1.RenderControl(htmlText);
            ViewData["Output"] = outString.ToString();
