    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    //...
    void SetField(WebBrowser wb, string formname, string fieldname, string fieldvalue) {
      HtmlElement f = wb.Document.Forms[formname].All[fieldname];
      f.SetAttribute("value", fieldvalue);
    }
    void SetRadio(WebBrowser wb, string formname, string fieldname, bool isChecked) {
      HtmlElement f = wb.Document.Forms[formname].All[fieldname];
      f.SetAttribute("checked", isChecked ? "True" : "False");
    }
    void SubmitForm(WebBrowser wb, string formname) {
      HtmlElement f = wb.Document.Forms[formname];
      f.InvokeMember("submit");
    }
    void ClickButtonAndWait(WebBrowser wb, string buttonname,int timeOut) {
      HtmlElement f = wb.Document.All[buttonname];
      webReady = false;
      f.InvokeMember("click");
      DateTime endTime = DateTime.Now.AddSeconds(timeOut);
      bool finished = false;
      while (!finished) {
        if (webReady)
          finished = true;
        Application.DoEvents();
        if (aborted)
          throw new EUserAborted();
        Thread.Sleep(50);
        if ((timeOut != 0) && (DateTime.Now>endTime)) {
          finished = true;
        }
      }
    }
    void ClickButtonAndWait(WebBrowser wb, string buttonname) {
      ClickButtonAndWait(wb, buttonname, 0);
    }
    void Navigate(string url,int timeOut) {
      webReady = false;
      webBrowser1.Navigate(url);
      DateTime endTime = DateTime.Now.AddSeconds(timeOut);
      bool finished = false;
      while (!finished) {
        if (webReady)
          finished = true;
        Application.DoEvents();
        if (aborted)
          throw new EUserAborted();
        Thread.Sleep(50);
        if ((timeOut != 0) && (DateTime.Now > endTime)) {
          finished = true;
        }
      }
    }
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
      webReady = true;
    }
