     public static class ControlExtensions
    {
        public static Control FindControl(this Control parent, Func<Control, bool> condition, bool recurse)
        {
            Control founded = null;
            Func<Control, bool> search = null;
            search = c => c != parent && condition(c) ? (founded = c) != null :
                                                        recurse ? c.Controls.FirstOrDefault(search) != null :
                                                        (founded = c.Controls.FirstOrDefault(condition)) != null;
            search(parent);
            return founded;
        }
    }
