    public class IdConstraint : IRouteConstraint {
        public bool Match(
            HttpContextBase Context,
            Route Route,
            string Parameter,
            RouteValueDictionary Dictionary,
            RouteDirection Direction) {
            try {
                int Param = Convert.ToInt32(Dictionary[Parameter]);
                using (DataContext dc = new DataContext() {
                    ObjectTrackingEnabled = false
                }) {
                    return (dc.Table.Any(
                        t =>
                            (t.Id == Param)));
                };
            } catch (Exception) {
                return (false);
            };
        }
    }
