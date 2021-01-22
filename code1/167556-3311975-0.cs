    private void TextBox1_KeyDown(object sender, 
      System.Windows.Forms.KeyEventArgs e)
    {
    	switch (e.KeyCode) {
    		case Keys.D0:
    		case Keys.D1:
    		case Keys.D2:
    		case Keys.D3:
    		case Keys.D4:
    		case Keys.D5:
    		case Keys.D6:
    		case Keys.D7:
    		case Keys.D8:
    		case Keys.D9:
    		case Keys.NumPad0:
    		case Keys.NumPad2:
    		case Keys.NumPad3:
    		case Keys.NumPad4:
    		case Keys.NumPad5:
    		case Keys.NumPad6:
    		case Keys.NumPad7:
    		case Keys.NumPad8:
    		case Keys.NumPad9:
    			//allow numbers only when no modifiers are active
    			if (e.Control || e.Alt || e.Shift) {
    				//suppress numbers with modifiers
    				e.SuppressKeyPress = true;
    				e.Handled = true;
    				Interaction.Beep();
    			}
    			break;
    		case Keys.OemPeriod:
    			if (!((TextBox)sender).Text.Contains(".")) {
    				//allow period key if there is no '.' 
    				//in the text and no modifiers are active
    				if (e.Control || e.Alt || e.Shift) {
    					//suppress numbers with modifiers
    					e.SuppressKeyPress = true;
    					e.Handled = true;
    					Interaction.Beep();
    				}
    			} else {
    				e.SuppressKeyPress = true;
    				e.Handled = true;
    				Interaction.Beep();
    			}
    			break;
    		case Keys.Subtract:
    		case Keys.OemMinus:
    			if (((TextBox)sender).SelectionStart == 0 && 
    			  !((TextBox)sender).Text.Contains("-")) {
    				//allow the negative key only when the cursor 
    				//is at the start of the textbox
    				//and there are no minuses in the textbox
    				//and no modifiers are active
    				if (e.Control || e.Alt || e.Shift) {
    					//suppress numbers with modifiers
    					e.SuppressKeyPress = true;
    					e.Handled = true;
    					Interaction.Beep();
    				}
    			} else {
    				e.SuppressKeyPress = true;
    				e.Handled = true;
    				Interaction.Beep();
    			}
    			break;
    		case Keys.C:
    		case Keys.X:
    		case Keys.V:
    		case Keys.Z:
    			//allow copy, cut, paste & undo by checking for 
    			//the CTRL state.
    			if (e.Control == false) {
    				e.SuppressKeyPress = true;
    				e.Handled = true;
    				Interaction.Beep();
    			}
    			break;
    		case Keys.Control:
    		case Keys.ControlKey:
    		case Keys.Alt:
    		case Keys.Shift:
    		case Keys.ShiftKey:
                //allow control, alt & shift
    			break;
    		case Keys.Left:
    		case Keys.Right:
    		case Keys.Up:
    		case Keys.Down:
    		case Keys.PageUp:
    		case Keys.PageDown:
    		case Keys.Home:
    		case Keys.End:
                //allow navigation keys
    			break;
    		case Keys.Back:
    		case Keys.Delete:
                //allow backspace & delete
    			break;
    		default:
    			//suppress any other key
    			e.SuppressKeyPress = true;
    			e.Handled = true;
    			Interaction.Beep();
    			break;
    	}
    }
