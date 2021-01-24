    using System;
    using System.Security.Permissions;
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Utilities;
    using Microsoft.SharePoint.Workflow;
    using System.Web;
    using System.Text;
    using System.Data.SqlClient;
    namespace SharePointFarmSolutionDev.DocumentEventReceiver
    {
        /// <summary>
        /// List Item Events
        /// </summary>
        public class DocumentEventReceiver : SPItemEventReceiver
        {
            private readonly HttpContext _currentContext;
            public DocumentEventReceiver()
            {
                if (_currentContext == null)
                {
                    _currentContext = HttpContext.Current;
                }
            }
            public override void ItemAdded(SPItemEventProperties properties)
            {
                 base.ItemAdded(properties);
                 //init
                 Guid listId = properties.ListId;
                 int itemId = properties.ListItemId;
                 SPSite site = properties.Site;
                 SPWeb web = properties.Web;
                 SPList list = web.Lists[listId];
                 SPListItem item = list.GetItemById(itemId);
                 item["title"] = "hello";
                 item.Update();
            }
       
                  
        }
    }
