    public static class EmployeeExtensions {
        public static string GetStatusText(this Employee emp) {
             /* do your funky thing, presumably using the HttpContext or
             some other thread-static value to resolve the current culture */
        }
    }
