    namespace App.Extensions
    {
        public static class IdentityExtensions
        {
            public static string GetDepartmentId(this IIdentity identity)
            {
                var claim = ((ClaimsIdentity)identity).FindFirst("DepartmentId");
                // Test for null to avoid issues during local testing
                return (claim != null) ? claim.Value : string.Empty;
            }
        }
    }
