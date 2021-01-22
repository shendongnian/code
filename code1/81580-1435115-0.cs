        private void ReadTaskandAddtask()
        {
            try
            {
                tcfifsharepoint.Lists listServiceBase = new tcfifsharepoint.Lists();
                // SharePoint Web Serices require authentication
                listServiceBase.Credentials = System.Net.CredentialCache.DefaultCredentials;
                listServiceBase.Url = "http://SPServer/Site/_vti_Bin/lists.asmx";
                String newIssueTitle = "Programmatically added issue 3";
                String listGUID = "FC519894-509A-4B66-861E-2813DDE14F46";
                String activeItemViewGUID = "C93FFC02-368B-4D06-A8AE-3A3BA52F4F0C";
                 listGUID = "{FC519894-509A-4B66-861E-2813DDE14F46}";
                 activeItemViewGUID = "{DCF35B63-F85C-463B-B1A1-716B4CF705C5}";
                // first check if item is already in the list
                XmlNode activeItemData = listServiceBase.GetListItems(listGUID, activeItemViewGUID, null, null, "", null, "");
                if (!activeItemData.InnerXml.Contains(newIssueTitle))
                {
                    //*********************This is Working *********************************
                    StringBuilder sb_method = new StringBuilder();
                    sb_method.Append("<Method ID=\"1\" Cmd=\"New\">");
                    sb_method.Append("<Field Name=\"Title\">Some Title 14</Field>");
                    sb_method.Append("<Field Name=\"AssignedTo\">Name to assign</Field>");
                    sb_method.Append("<Field Name=\"Status\">In Progress</Field>");
                    sb_method.Append("<Field Name=\"Priority\">(3) Low</Field>");
                    sb_method.Append("<Field Name=\"DueDate\">");
                    sb_method.Append(DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-ddTHH:mm:ssZ"));
                    sb_method.Append("</Field>");
                    sb_method.Append("<Field Name=\"PercentComplete\">.34</Field>");
                    sb_method.Append("<Field Name=\"Body\">Something entered into the description field.</Field>");
                    sb_method.Append("<Field Name=\"Author\">Your Author</Field>");
                    sb_method.Append("<Field Name=\"Editor\">This is Modified By</Field>");
                    sb_method.Append("</Method>");
                    XmlDocument x_doc = new XmlDocument();
                    XmlElement xe_batch = x_doc.CreateElement("Batch");
                    xe_batch.SetAttribute("OnError", "Return");
                    xe_batch.InnerXml = sb_method.ToString();
                    XmlNode xn_return = listServiceBase.UpdateListItems("Task List Name", xe_batch);
            }
            catch (Exception e)
            {
                string sMessage = e.Message;
            }
        }
