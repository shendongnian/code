    [Flags]
    public enum SiteRoles
    {
        User = 1 << 12,
        Admin = 1 << 13,
        Helpdesk = 1 << 15,
        AdvancedUser = User | Helpdesk, //or (1<<12)|(1<<13)
    }
    
    [Flags]
    public enum SiteRoles
    {
        User = 4096, //not so obvious!
        Admin = 8192,
        Helpdesk = 16384,
        AdvancedUser = 12288, //!
    }
    
    [Flags]
    public enum SiteRoles
    {
        User = 0x1000, //we can use hexademical digits
        Admin = 0x2000,
        Helpdesk = 0x4000,
        AdvancedUser = 0x3000, //it much simpler calculate binary operator OR with hexademicals
    }
