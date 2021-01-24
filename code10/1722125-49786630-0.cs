     WebBrowser webBrowser1 = new WebBrowser();
            string myquery = "";
            string html = "";
            string results = "";
            int start;
            int end;
            //string encodage = "";
    
            webBrowser1.ScriptErrorsSuppressed = true;
            myquery = "http://citoyens.soquij.qc.ca/index.php";
            webBrowser1.Navigate(myquery);
            do
            {
                Application.DoEvents();
            } while (webBrowser1.ReadyState != WebBrowserReadyState.Complete);
    
            // For UTF-8 encoding. 
            //StreamReader sr = new StreamReader(webBrowser1.DocumentStream, Encoding.GetEncoding("UTF-8"));
            //string source = sr.ReadToEnd();
            //string encodage = webBrowser1.Document.Encoding;
            //MessageBox.Show(encodage);
    
    
            // Similarly, For Similary for "iso-8859-1" character set encoding.
            using (StreamReader sr = new StreamReader(webBrowser1.DocumentStream, Encoding.GetEncoding(webBrowser1.Document.Encoding)))
            {
                string source = sr.ReadToEnd();
                webBrowser1.Document.Write(source);
            }
      
            html = webBrowser1.DocumentText;
            start = html.IndexOf("a class=\"petit_logo\"");
            start = html.IndexOf(">", start);
            end = html.IndexOf("<", start);
            results += html.Substring(start, end - start);
            //webBrowser1.Document.Encoding = encodage;
            webBrowser1.DocumentText = results; //use Document.write(text) method.
