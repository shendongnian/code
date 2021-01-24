    // Will only see properties BackColor and MouseOverBackColor
    private IDesktopProperties myProps;
    public MyDesktopUI( IDesktopProperties properties ) // <= injected: MySuperFancyViewModel 
    {
        myProps = properties;
    }
