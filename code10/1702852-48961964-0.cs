    public class WebTestDependentFilter : WebTestPlugin
    {
        public string FilterDependentRequestsThatStartWith { get; set; }
        public string FilterDependentRequestsThatEndWith { get; set; }
        public override void PostRequest(object sender, PostRequestEventArgs e)
        {
            WebTestRequestCollection depsToRemove = new WebTestRequestCollection();
            // Note, you can't modify the collection inside a foreach, hence the second collection
            // requests to remove.
            foreach (WebTestRequest r in e.Request.DependentRequests)
            {
                if (!string.IsNullOrEmpty(FilterDependentRequestsThatStartWith))
                {
                    if (r.Url.StartsWith(FilterDependentRequestsThatStartWith))
                    {
                        depsToRemove.Add(r);
                    }
                }
                else if (!string.IsNullOrEmpty(FilterDependentRequestsThatEndWith))
                {
                    if (r.Url.EndsWith(FilterDependentRequestsThatEndWith))
                    {
                        depsToRemove.Add(r);
                    }
                }
            }
            foreach (WebTestRequest r in depsToRemove)
            {
                e.WebTest.AddCommentToResult(string.Format("Removing dependent: {0}", r.Url));
                e.Request.DependentRequests.Remove(r);
            }
        }
    }
