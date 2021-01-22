        using System.Collections.Generic;
        using System.Linq;
        using System.Windows.Forms;
        using System.Xml.Linq;
        using System.Net;
        using System.IO;
        // This method uses an map List<FieldMap> created from an XML file to map fields in the
        // 2003 SharePoint list to the new 2007 SharePoint list.
        private object PopulateFields(XElement batchItem, XElement listItem)
        {
            foreach (FieldMap mapItem in FieldMaps)
            {
                if (listItem.Attribute(mapItem.OldField) != null)
                {
                    batchItem.Element("Method").Add(new XElement("Field",
                        new XAttribute("Name", mapItem.NewField),
                            listItem.Attribute(mapItem.OldField).Value));
                }
            }
            return listItem;
        }
        private static string GetID(XElement elem)
        {
            XNamespace z = "#RowsetSchema";
            XElement temp = elem.Descendants(z + "row").First();
            return temp.Attribute("ows_ID").Value;
        }
        private static string GetListItemIDString(XElement listItem)
        {
            XAttribute field = listItem.Attribute("ows_ID");
            return field.Value;
        }
        private void SetupServices()
        {
            _listsService2003 = new SPLists2003.Lists();
            _listsService2003.Url = "http://oldsite/_vti_bin/Lists.asmx";
            _listsService2003.Credentials = new System.Net.NetworkCredential("username", "password", "domain");
            _listsService2007 = new SPLists2007.Lists();
            _listsService2007.Url = "http://newsite/_vti_bin/Lists.asmx";
            _listsService2007.Credentials = new System.Net.NetworkCredential("username", "password", "domain");
        }
        private string _listNameGuid = "SomeGuid";      // Unique ID for the old SharePoint List.
        private string _viewNameGuid = "SomeGuid";      // Unique ID for the old SharePoint View that has all the fields needed.
        private string _newListNameGuid = "SomeGuid";   // Unique ID for the new SharePoint List (target).
        private SPLists2003.Lists _listsService2003;    // WebService reference for the old SharePoint site (2003 or 2007 is fine).
        private SPLists2007.Lists _listsService2007;    // WebService reference for the new SharePoint site.
        private List<FieldMap> FieldMaps;   // Used to map the old list to the new list. Populated with a support function on startup.
        class FieldMap
        {
            public string OldField { get; set; }
            public string OldType { get; set; }
            public string NewField { get; set; }
            public string NewType { get; set; }
        }
