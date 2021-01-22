       void TraverseNode(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(new StreamReader(path, System.Text.Encoding.UTF8));
            XmlNodeList _nodeList = xmlDocument.SelectNodes("//session");
            string strxml = "";
            string completexml = "";
            for (int inode = 0; inode < _nodeList.Count; inode++)
            {
                if(inode==0)
                    strxml = formatxml(_nodeList[inode].OuterXml).ChildNodes[0].ChildNodes[0].OuterXml;
                else
                    strxml = formatxml("<session>" + _nodeList[inode].OuterXml + "</session>").ChildNodes[0].ChildNodes[0].OuterXml;
                completexml += strxml;
                strxml = "";
                
            }
            XmlDocument newxml = new XmlDocument();
            newxml.LoadXml("<session>" + completexml + "</session>");
            newxml.Save(@"C:\Working\Teradata\ssis\out_18.xml");
        }
        XmlDocument formatxml(string xml)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            XmlNode nodeListOtherInterest = xmlDocument.SelectSingleNode("//session/data/account/additionalOtherInterest/address");
            XmlNode acAddress = xmlDocument.SelectSingleNode("//session/data/account/address");
            XmlNode locationaddress = xmlDocument.SelectSingleNode("//session/data/account/location/address");
            XmlNode lineaddress = xmlDocument.SelectSingleNode("//session/data/policy/line/address");
            string strotherinterest = "";
            string stracAddress = "";
            string strlocationaddress = "";
            string strlineaddress = "";
            string straddressess="";
          
            XmlNodeList statecodes;
            statecodes = xmlDocument.SelectNodes("//session/data/policy/line/linestate/linestateterm/coverage/statCode");
            for (int i = 0; i < statecodes.Count; i++)
            {
                if(statecodes[i].InnerText=="0")
                    statecodes[i].ParentNode.RemoveChild(statecodes[i]);
            }
            if (xmlDocument.SelectSingleNode("//session/data/account/additionalOtherInterest/address") != null)
            {
                strotherinterest = "<address_otherinterest>" + nodeListOtherInterest.InnerXml + "</address_otherinterest>";
                nodeListOtherInterest.ParentNode.RemoveChild(nodeListOtherInterest);
            }
            if (xmlDocument.SelectSingleNode("//session/data/account/address") != null)
            {
                stracAddress = "<address_Account>" + acAddress.InnerXml + "</address_Account>";
                acAddress.ParentNode.RemoveChild(acAddress);
            }
            if (xmlDocument.SelectSingleNode("//session/data/account/location/address") != null)
            {
                strlocationaddress = "<address_location>" + locationaddress.InnerXml + "</address_location>";
                locationaddress.ParentNode.RemoveChild(locationaddress);
            }
            if (xmlDocument.SelectSingleNode("//session/data/policy/line/address") != null)
            {
                strlineaddress = "<address_line>" + lineaddress.InnerXml + "</address_line>";
                lineaddress.ParentNode.RemoveChild(lineaddress);
            }
            straddressess= "<addressess>"+strotherinterest +stracAddress+strlocationaddress+strlineaddress + "</addressess>";
            XmlDocument address = new XmlDocument();
            address.LoadXml(straddressess);
            XPathNavigator pnav = xmlDocument.CreateNavigator();
            pnav.MoveToChild("session", "");
            pnav.MoveToChild("session","");
            pnav.AppendChild(straddressess);
            return xmlDocument;
        }
