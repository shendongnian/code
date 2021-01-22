    //Returns all controls in all levels:
    public static IEnumerable<Control> AllControls( this Control theStartControl )
    {
       var controlsInThisLevel = theStartControl.Controls.Cast<Control>();
       return controlsInThisLevel.SelectMany( AllControls ).Concat( controlsInThisLevel );
    }
    
    //Returns all controls of a certain type in all levels:
    public static IEnumerable<Control> AllControls<TheControlType>( this Control theStartControl ) where TheControlType : Control
    {
       var controlsInThisLevel = theStartControl.Controls.Cast<Control>();
       return controlsInThisLevel.SelectMany( AllControls<TheControlType> ).Concat( controlsInThisLevel.OfType<TheControlType>() );
    }
    
    //(Another way) Returns all controls of a certain type in all levels, integrity derivation:
    public static IEnumerable<Control> AllControlsOfType<TheControlType>( this Control theStartControl ) where TheControlType : Control
    {
       return theStartControl.AllControls().OfType<TheControlType>();
    }
