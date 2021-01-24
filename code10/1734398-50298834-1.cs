    [System.Runtime.InteropServices.ComVisible(true)]
    public class ScriptInterface
    {
        public void OnAnchorClick(string href)
        {
            var parts = href.Split('#');
            var pageName = parts[0];
            //do whatever with page name    
        }
    }
