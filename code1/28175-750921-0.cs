    public static void CssAddClass(this WebControl control, string className)
    {
        var classNames = control.CssClass.Split
            (new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
     
        if (classNames.Contains(className))
        {
            return;
        }
    
        control.CssClass = string.Concat
            (classNames.Select(name => name + " ").ToArray()) + className;
    }
    
    public static void CssRemoveClass(this WebControl control, string className)
    {
        var classNames = from name in control.CssClass.
                             Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                         where name != className
                         select name + " ";
        
    
        control.CssClass = string.Concat(classNames.ToArray()).TrimEnd();
    }
