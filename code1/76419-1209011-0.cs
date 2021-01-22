            ListsService.Lists listService = new Risk_Form.ListsService.Lists();
            listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            XmlNode list = null;
            
            list = listService.GetListAndView("Risks", "");
           
            string listID = list.ChildNodes[0].Attributes["Name"].Value;
            string viewID = list.ChildNodes[1].Attributes["Name"].Value;
            
            string riskID = thisXDocument.DOM.selectSingleNode("//my:myFields/my:RiskID").text;
            string headline = thisXDocument.DOM.selectSingleNode("//my:myFields/my:RiskHeadline").text;
            XmlDocument doc = new XmlDocument();
            XmlElement batch = doc.CreateElement("Batch");
            batch.SetAttribute("OnError", "Continue");
            batch.SetAttribute("ListVersion", "1");
            batch.SetAttribute("ViewName", viewID);
            batch.InnerXml = 
                "<Method ID='1' Cmd='New'>" +
                    "<Field Name='RiskID'>" + riskID + "</Field>" +
                    "<Field Name='Headline'>" + headline + "</Field>" + 
                "</Method>";
            XmlNode ret = listService.UpdateListItems(listID, batch);
            MessageBox.Show(ret.OuterXml);
