    bool statusAuthorization;
    private void Frm5UC_Load(object sender, EventArgs e)
    {
            webBrowser1.Visible = true;
            statusAuthorization = true; // !!! CHANGES
            // *** ТЕСТ ***
           
    }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if (webBrowser1.ReadyState != WebBrowserReadyState.Complete) return;
        if (statusAuthorization == true && webBrowser1.Document != null)
        { Method_1();
            Authorization();
        }
    }
        #region *** TESTS ***
       
        public void  Method_1()
        {
            textBox2.Text = "_domain_com";
            textBox1.Text = @"domain_com/login/";
            
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {Method_1();
            Authorization();
        }       
        public void Authorization() // Авторизация
        {            
                foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("input"))
                {
                    if (he.GetAttribute("name") == "login[login]")
                    {
                        he.SetAttribute("value", "login798");
                    }
                }
            // Code "enter password"
            // Code "Press the button"
            statusAuthorization = false; // !!! CHANGES
        }
