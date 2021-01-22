            var tbl = new System.Web.UI.WebControls.Table();
            DirectoryInfo di = new DirectoryInfo("some directory");
            FileInfo[] files = di.GetFiles("*.dll", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                Assembly assembly = Assembly.LoadFile(file.FullName);
                string version = assembly.GetName().Version.ToString();
                var tr = new System.Web.UI.WebControls.TableRow();
                var tc = new System.Web.UI.WebControls.TableCell();
                tc.Text = version;
                tr.Cells.Add(tc);
                tbl.Rows.Add(tr);
            }
            using (var ts = new StringWriter())
            using (var html = new System.Web.UI.HtmlTextWriter(ts))
            {
                // Not entirely sure about this part
                tbl.RenderControl(html);
                html.Flush();
                string htmlString = ts.ToString();
            }
