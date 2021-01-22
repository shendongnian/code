    public static bool IsAnyInDesignMode(Control control){
        while(control != null){
            if(control.Site != null && control.Site.DesignMode)
                return true;
            control = control.Parent;
        }
        return false;
    }
