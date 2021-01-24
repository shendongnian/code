    namespace Your.Project.Helpers
    {
        public static class PropertyHelper
        {
            public static string GetValueOrDefault(this Property p) // use actual type (or interface)
            {
                return p.HasValue ? p.Value : null;
            }
        }
    }
