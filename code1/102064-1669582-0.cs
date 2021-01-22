    XmlDocument doc;
    
    function SaveForm()
    {
       doc = new XmlDocument("FormInfo");
       foreach(Control ctrl in this.Controls)
       {
          AddControlToXml(ctrl, doc.Documentelement);
       }
    }
    
    function AddControlToXml(Control ctrl, XmlNode currentNode)
    {
       XmlNode n = new XmlNode;
       Node.InnerText = ctrl.Name;
       foreach(Control ctrl2 in ctrl.Controls)
       {
          AddControlToXml(ctrl2);
       }
    
    }
