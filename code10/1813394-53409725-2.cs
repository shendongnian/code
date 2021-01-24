    namespace Your.Project.Helpers
    {
        public static class PropertyHelper
        {
                                                   // use actual type (or interface)
            public static string GetValueOrDefault(this Property p) 
            {
                return p.HasValue ? p.Value : null;
            }
        }
    }
