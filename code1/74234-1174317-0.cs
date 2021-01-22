     private void button1_Click(object sender, EventArgs e)
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Multiselect = true;
                OFD.Filter = "HTML Files (*.htm*)|*.HTM*|" +
              "All files (*.*)|*.*";
    
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    foreach (string s in OFD.FileNames)
                    {
                        Console.WriteLine(s);
                        AddAnalytics(s);
                    }
                    MessageBox.Show("done!");
                }
            }
            private void AddAnalytics(string filename)
            {
    
                string Htmlcode = "";
                using (StreamReader sr = new StreamReader(filename))
                {
                    Htmlcode = sr.ReadToEnd();
                }
                if (!Htmlcode.Contains(textBox1.Text))
                {
                    Htmlcode = Htmlcode.Replace("</body>", CreateCode(textBox1.Text) + "</body>");
                    
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        sw.Write(Htmlcode);
                    }
                }
            }
    
            private string CreateCode(string Number)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("<script type=\"text/javascript\">");
                sb.AppendLine("var gaJsHost = ((\"https:\" == document.location.protocol) ? \"https://ssl.\" : \"http://www.\");");
                sb.AppendLine("document.write(unescape(\"%3Cscript src='\" + gaJsHost + \"google-analytics.com/ga.js' ");
                sb.AppendLine("<//script>");
                sb.AppendLine("<script type=/\"text//javascript/\">");
                sb.AppendLine("try {");
                sb.AppendLine(string.Format("var pageTracker = _gat._getTracker(/\"{0}/\");", Number));///"UA-9909000-1"
                sb.AppendLine("pageTracker._trackPageview();");
                sb.AppendLine("} catch(err) {}<//script>");
                sb.AppendLine();
                return sb.ToString();
            }
        }
