    public static class PropertyGrouper  {
        public static void GroupProperties(IGrouping itemToGroup) {
            //has this been done before, if yes, return
            if (itemToGroup.StringProperties.Count > 0 || itemToGroup.BoolProperties.Count > 0 || itemToGroup.LongProperties.Count > 0 ) {
                return;
            }
            //otherwise
            if (itemToGroup.boolProp != null) {
                foreach (var bProp in itemToGroup.boolProp) {
                    var succeeded = bool.TryParse(bProp.Value, out var bValue);
                    itemToGroup.BoolProperties.Add(bProp.name, succeeded ? bValue : (bool?)null);
                }
            }
            if (itemToGroup.longProp != null) {
                foreach (var lProp in itemToGroup.longProp) {
                    var succeeded = long.TryParse(lProp.Value, out var lValue);
                    itemToGroup.LongProperties.Add(lProp.name, succeeded ? lValue : (long?)null);
                }
            }
            if (itemToGroup.stringProp != null) {
                foreach (var sProp in itemToGroup.stringProp) {
                    itemToGroup.StringProperties.Add(sProp.name, sProp.Value);
                }
            }
        }
    }
