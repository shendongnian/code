    bool statusAuthorization;
    private void Frm5UC_Load(object sender, EventArgs e)
    {
            webBrowser1.Visible = true;
            statusAuthorization = true; // !!! CHANGES
            // *** ТЕСТ ***
            Method_0();
    }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if (webBrowser1.ReadyState != WebBrowserReadyState.Complete) return;
        if (statusAuthorization == true)
        {
            Authorization();
        }
    }
        #region *** TESTS ***
        public void Method_0()
        {
            Method_1();
           
        }
        public void  Method_1()
        {
            textBox2.Text = "_domain_com";
            textBox1.Text = @"domain_com/login/";
            
        }
        public void Method_2() // Авторизация
        {
            Authorization();
        }
        #endregion *** TESTS ***
        
        private void button1_Click(object sender, EventArgs e)
        {
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
