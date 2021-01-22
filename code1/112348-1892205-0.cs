    private void button2_Click(object sender, EventArgs e)
    {
        SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
        foreach (SHDocVw.WebBrowser ie in shellWindows)
        {
            mshtml.HTMLDocument doc = ie.Document as mshtml.HTMLDocument;
            if (doc != null)
            {
                foreach (mshtml.HTMLImg imgElement in doc.images)
                {
                    ((HTMLImgEvents_Event)imgElement).onclick += new mshtml. HTMLImgEvents_onclickEventHandler(Form1_onclick); 
                    Console.WriteLine(imgElement.href);
                    imgElement.click();
                }
            }
        }
    }
    
    private bool Form1_onclick()
    {
        Console.WriteLine("click !!");            
        return true;
    }
