        public static AutomationElement FindElement(AutomationElement context, PropertyCondition[] conditions)
        {
            // if no conditions, there's no search to do: just return the context, will be used as target
            if (conditions == null)
            {
                return (context);
            }
            // create the condition to find
            System.Windows.Automation.Condition condition = null;
            if (conditions.Length <= 0)
            {
                throw (new ArgumentException("No conditions specified"));
            }
            else if (conditions.Length == 1)
            {
                condition = conditions[0];
            }
            else
            {
                AndCondition ac = new AndCondition(conditions);
                condition = ac;
            }
            // find the element
            CacheRequest creq = new CacheRequest();
            creq.TreeFilter = Automation.ControlViewCondition;
            using (creq.Activate())
            {
                AutomationElement e = AutomationContext(context);
                AutomationElement target = e.FindFirst(TreeScope.Subtree, condition);
                return (target);
            }
        }
