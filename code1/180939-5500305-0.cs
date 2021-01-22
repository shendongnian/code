    HtmlElementCollection theElementCollection = default(HtmlElementCollection);
       theElementCollection = webBrowser1.Document.GetElementsByTagName("span");
       foreach (HtmlElement curElement in theElementCollection)
       {
            //If curElement.GetAttribute("classname").ToString = "example"  It doesn't work.  
            // This should be the work around.
            if (curElement.GetAttribute("classname").ToString = "example")
            {
                MessageBox.Show(curElement.GetAttribute("InnerText")); // Doesn't even fire.
                // InvokeMember(test) after class is found.
            }
        }
