    public static class Categories
    {
        public const string Outlink = "Outlink";
        public const string Login = "Login";
    }
    public enum Action
    {
        /// <summary>
        /// Outlink is a anchor tag pointing to an external host
        /// </summary>
        [Action(Categories.Outlink, "Click")]
        OutlinkClick,
        [Action(Categories.Outlink, "ClickBlocked")]
        OutlinkClickBlocked,
        /// <summary>
        /// User account events
        /// </summary>
        [Action(Categories.Login, "Succeeded")]
        LoginSucceeded,
        [Action(Categories.Login, "Failed")]
        LoginFailed
    }
    public class ActionAttribute : Attribute
    {
        public string Category { get; private set; }
        public string Action { get; private set; }
        public ActionAttribute(string category, string action)
        {
            Category = category;
            Action = action;
        }
    }
