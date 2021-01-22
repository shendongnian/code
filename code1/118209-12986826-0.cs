        private static string GetUrlFromFirefox(IntPtr windowHandle)
        {
            SystemAccessibleObject sao = SystemAccessibleObject.FromWindow(new SystemWindow(windowHandle), AccessibleObjectID.OBJID_WINDOW);
            var preds = new Predicate<SystemAccessibleObject>[] { 
                s => s.RoleString == "application",
                s => s.RoleString == "property page",
                s => s.RoleString == "grouping" && s.StateString == "None",
                s => s.RoleString == "property page" && s.StateString == "None",
                s => s.RoleString == "browser",
                s => s.RoleString == "document" && s.Visible
            };
            var current = sao.Children;
            SystemAccessibleObject child = null;
            foreach (var pred in preds)
            {
                child = Array.Find(current, pred);
                if (child != null)
                {
                    current = child.Children;
                }
            }
            if (child != null)
            {
                return child.Value;
            }
            return string.Empty;
        }
