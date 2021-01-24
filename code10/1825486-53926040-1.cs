    public class ContentManagerUnitOfWork : IContentManagerUnitOfWork, IDisposable
    {
        private ClientContext clientContext;
        private Web web;
        public ContentManagerUnitOfWork(string url, username, password)
        {
            clientContext = new ClientContext(url);
            clientContext .Credentials = new SharePointOnlineCredentials(username, password);
            web = context.Web;
        }
        public IEnumerable<List> GetLists()
        {
            clientContext.Load(web.Lists);
            clientContext.ExecuteQuery(); 
            return web.Lists;
        }
        List CreateList(ListCreationInformation listCreationInformation)
        {
            List list = web.Lists.Add(listCreationInformation); 
            list.Update(); 
            clientContext.ExecuteQuery(); 
            return list;
        }
        List GetListByTitle(string title)
        {
            return web.Lists.GetByTitle("Announcements"); 
        }
        
        public void Dispose()
        {
            clientContext.Dispose();
        }
    }
