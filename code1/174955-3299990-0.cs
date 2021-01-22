public class MyViewModel 
{
    private bool _textChanged = false;
    private String _oldValue = String.Empty;
    TextChanged( ... )
    {
        // The user modifed the text, set our flag
        _textChanged = true;        
    }
    OnLostFocus( ... )
    {
       // Has the text changed?
       if( _textChanged )
       {
          // Do work with _oldValue and the current value of the textbox          
          // Finished work save the new value as old
          _oldValue = myText.Text;
          // Reset changed flag
          _textChanged = false;
       }       
       
    }
}
