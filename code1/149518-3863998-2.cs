    class OnOffButton : I_OnOffButton
    {
         Button regularButton;
         bool bIsOn = true;
         public bool On
         {
          set 
             {
             bIsOn=value;
    
             bIsOn?(regularButton.Text = "ON"):(regularButton.Text = "OFF")
             regularButton.Invalidate(); //force redrawing
            }
         }
    ...
    
    }
