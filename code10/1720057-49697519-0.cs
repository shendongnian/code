        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading;
        using System.Threading.Tasks;
        using Microsoft.AspNet.SignalR;
        using Microsoft.AspNet.SignalR.Hubs;
        
        namespace CHSI.Shared.APIs
        {
    
        [HubName("applicationMessageHub")]
        public class ApplicationMessageHub : Hub
        {
             
     
            private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(5000);
            private IList< DSIDGroup> DSIDGroups = new List<DSIDGroup>();
            public ApplicationMessageHub() 
            {
               
                
            }
            public void CheckMessages(object state)
            {
                GetMessages();
    
            }
    
            public Models.ApplicationMessage GetCurrentMessage(int DSID)
            {
                Models.ApplicationMessage currentMessage = null;
               
                
                return currentMessage;
            }
    
            public override Task OnConnected()
            {
                string DSID = Context.QueryString["DSID"];
                if (!string.IsNullOrEmpty(DSID))
                {
                    Groups.Add(Context.ConnectionId, DSID);
                    
                    DSIDGroup currentGroup = (from g in this.DSIDGroups where g.DSID == DSID select g).FirstOrDefault();
                    if (currentGroup != null)
                    {
                        
                        currentGroup.ConnecedIDs.Add(Context.ConnectionId);
                    }
                    else
                    {
                        currentGroup = new DSIDGroup();
                        currentGroup.DSID = DSID;
                        
                        currentGroup.ConnecedIDs.Add(Context.ConnectionId);
                        this.DSIDGroups.Add(currentGroup);
                    }
                }
                
                return base.OnConnected();
            }
    
            public override Task OnDisconnected(bool stopCalled)
            {
                foreach (var DSIDgroup in DSIDGroups)
                {
                    if (DSIDgroup.ConnecedIDs.Contains(Context.ConnectionId))
                    {
                        DSIDgroup.ConnecedIDs.Remove(Context.ConnectionId);
                        if (DSIDgroup.ConnecedIDs.Count == 0)
                        {
                            DSIDGroups.Remove(DSIDgroup);
                        }
    
                        break;
                    }
    
                }
    
    
                return base.OnDisconnected(stopCalled);
            }
    
            public void BroadcastMessage(Models.ApplicationMessage message)
            {
    
                Clients.All.SendMessage(message);
            }
    
            public void clearCache(int DSID)
            {
                Clients.Group(DSID.ToString()).clearCache();
            }
            public Models.ApplicationMessage GetMessages()
            {
                
                foreach (var group in this.DSIDGroups)
                {
                    Models.ApplicationMessage currentMessage = GetCurrentMessage(Convert.ToInt32(group.DSID));
                    if (currentMessage != null)
                    {
                        Clients.Group(group.DSID).SendMessage(currentMessage);
                    }
                    
                }
                return null;
                //return _applicationMessage.GetCurrentMessage();
            }
    
        }
        public class DSIDGroup
    {
        public string DSID {get;set;}
        
        public IList<string> ConnecedIDs { get;set; }
        public DSIDGroup()
        {
            this.ConnecedIDs = new List<string>();
        }
    }
    }
