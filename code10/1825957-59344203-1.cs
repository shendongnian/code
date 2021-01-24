    using System.Collections.Generic;
    
    namespace BlazorSessionApp.Helpers
    {
        public class SessionState
        {
            public SessionState()
            {
                Items = new Dictionary<string, object>();
            }
           public Dictionary<string, object> Items { get; set; }
        }
    }
