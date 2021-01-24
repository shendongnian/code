        public class SysParent
        {
            public Sys sys { get; set; }
        }
        public class Sys
        {
            public string id { get; set; }
            public string type { get; set; }
            public string linkType { get; set; }
        }
            var Cards = new Dictionary<string, List<SysParent>>()
            {
                { "en-US" , new List<SysParent>{ new SysParent{
                    sys = new Sys { id = "7Ll4cezI6QMYsgIUwMCmSw", type = "Link", linkType = "Entry" } }
                } }
            };
