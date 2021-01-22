            private void TransferListItems()
        {
            XElement listItems = _listsService2003.GetListItems(_listNameGuid, _viewNameGuid, null, null, "", null).GetXElement();
            XNamespace z = "#RowsetSchema";
            foreach (XElement listItem in listItems.Descendants(z + "row"))
            {
                AddNewListItem(listItem);
            }
        }
        private void AddNewListItem(XElement listItem)
        {
            // SharePoint XML for adding new list item.
            XElement newItem = new XElement("Batch",
                new XAttribute("OnError", "Return"),
                new XAttribute("ListVersion", "1"),
                new XElement("Method",
                    new XAttribute("ID", "1"),
                    new XAttribute("Cmd", "New")));
            // Populate fields from old list to new list mapping different field names as necessary.
            PopulateFields(newItem, listItem);
            XElement addResults = _listsService2007.UpdateListItems(_newListNameGuid, newItem.GetXmlNode()).GetXElement();
            // Address attachements.
            if (HasAttachments(listItem))
            {
                AddAttachments(addResults, listItem);
            }
        }
        private static bool HasAttachments(XElement listItem)
        {
            XAttribute attachments = listItem.Attribute("ows_Attachments");
            if (System.Convert.ToInt32(attachments.Value) != 0)
                return true;
            return false;
        }
