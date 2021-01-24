    UserAction[] userActions = dbContext.UserActions.ToArray();
    var distinctActions = userActions
        .OrderByDescending(ua => ua.Date)             // sort as you like here
        .GroupBy(ua => ua.UserName)                   // group by user          
        .SelectMany(ua => ua)                         // select all actions in the group
        .Distinct(new UserActionAndHourComparer());   // apply filter
    public class UserActionAndHourComparer : IEqualityComparer<UserAction> {
		
		public bool Equals(UserAction left, UserAction right){
			if (left == null && right == null) {
				 return true;
			}
			if (left == null | right == null) {
				return false;
			}
            // your equality criteria here ...
			if (left.UserName == right.UserName && left.Action == right.Action) {
                // implement requirement that same hour is considered equal
				return left.Date.Date == right.Date.Date && left.Date.Hour == right.Date.Hour;
			}
            return false;
       }
		
        // if two UserActions are considered equal, they should yield the same hashcode
		public int GetHashCode(UserAction ua) {
			return ua.UserName.GetHashCode() 
				^ ua.Action.GetHashCode() 
				^ new DateTime(ua.Date.Year, ua.Date.Month, ua.Date.Day, ua.Date.Hour, 0, 0).GetHashCode();
		}
	}
