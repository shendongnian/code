    //Returns all controls of a certain type in all levels:
    public static IEnumerable<TheControlType> AllControls<TheControlType>( this Control theStartControl ) where TheControlType : Control
    {
       var controlsInThisLevel = theStartControl.Controls.Cast<Control>();
       return controlsInThisLevel.SelectMany( AllControls<TheControlType> ).Concat( controlsInThisLevel.OfType<TheControlType>() );
    }
    
    //(Another way) Returns all controls of a certain type in all levels, integrity derivation:
    public static IEnumerable<TheControlType> AllControlsOfType<TheControlType>( this Control theStartControl ) where TheControlType : Control
    {
       return theStartControl.AllControls().OfType<TheControlType>();
    }
