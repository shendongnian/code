        private void kb_openkey(CoreWindow sender, KeyEventArgs e)
        {
            //Mark the event as handled
            e.Handled = true;
            
            int keypressed = (int) e.VirtualKey;
            //Than handle the key, based on its keycode
            if ((int)keypressed >= 1 && (int)keypressed <= 255)
            {                
                switch (keypressed)
                {
                    case 70: //F
                        //do something when F is presed
                        break;
                    case 76:  //L dialog to show items
                        //Do something when L is pressed
                        break;
                }
            }
         }
