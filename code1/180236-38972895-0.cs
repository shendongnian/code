    public static IEnumerable<Control> GetAll(this Control control, IEnumerable<Type> filteringTypes)
    {
        var ctrls = control.Controls.Cast<Control>();
    
        return ctrls.SelectMany(ctrl => GetAll(ctrl, filteringTypes))
                    .Concat(ctrls)
                    .Where(ctl => filteringTypes.Any(t => ctl.GetType() == t));
    }
