    public class ContextActionInvoker : ControllerActionInvoker
    {
        public const string testMessageCacheAndViewDataKey = "TESTMESSAGE";
        private const int testListLifetimeInMinutes = 10;
        public ContextActionInvoker(ControllerContext controllerContext) : base() { }
        public override bool InvokeAction(ControllerContext context, string actionName)
        {
            // Cache a test list if not already done so
            var list = context.HttpContext.Cache[testMessageCacheAndViewDataKey];
            if (list == null)
            {
                list = new SelectList(new[] {
                    new SelectListItem { Text = "Text 10", Value = "10" },
                    new SelectListItem { Text = "Text 15", Value = "15", Selected = true },
                    new SelectListItem { Text = "Text 25", Value = "25" },
                    new SelectListItem { Text = "Text 50", Value = "50" },
                    new SelectListItem { Text = "Text 100", Value = "100" },
                    new SelectListItem { Text = "Text 1000", Value = "1000" }
                }, "Value", "Text");
                context.HttpContext.Cache.Insert(testMessageCacheAndViewDataKey, list, null, DateTime.Now.AddMinutes(testListLifetimeInMinutes), TimeSpan.Zero);
            }
            context.Controller.ViewData[testMessageCacheAndViewDataKey] = list;
            return base.InvokeAction(context, actionName);
        }
    }
