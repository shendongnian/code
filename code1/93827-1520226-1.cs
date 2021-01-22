    using TKageyu.Utils;
    
    ...
    
    using (IconExtractor ie = new IconExtractor(@"D:\sample.exe")) 
    {
        Icon icon0 = ie.GetIcon(0);
        Icon icon1 = ie.GetIcon(1);
    
        ...
        
        Icon[] splitIcons = IconExtractor.SplitIcon(icon0);
    
        ...
    }
