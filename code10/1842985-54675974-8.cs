        private void searchButton_Click(object sender, EventArgs e)
        {
            var txt = searchTextBox.Text;
            var rpt = new ReportTemplate();
            rpt.Session = new Dictionary<string, object>();
            rpt.Session["Model"] = list.Where(x => x.LTR.Contains(txt) ||
                x.RTL.Contains(txt)).ToList();
            rpt.Initialize();
            webBrowser1.DocumentText = rpt.TransformText();
        }
