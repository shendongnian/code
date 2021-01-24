    private void Form1_Load(object sender, EventArgs e)
            {
                button2.Enabled = false;
                try {
                    gHook = new GlobalKeyboardHook(); // Create a new GlobalKeyboardHook
                                                      // Declare a KeyDown Event
                    gHook.KeyUp += new KeyEventHandler(gHook_KeyUp);
                    gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
                    // Add the keys you want to hook to the HookedKeys list
                    foreach (Keys key in Enum.GetValues(typeof(Keys)))
                        gHook.HookedKeys.Add(key);
                }
                catch (Exception z)
                {
    
                }
    
            }
    public void gHook_KeyDown(object sender, KeyEventArgs e)
            {
    
                String getCharVar = getCharDown(e.KeyValue);
               if(getCharVar!=null)
                    richTextBox1.Text += getCharVar;
    
            }
 
    private String getCharDown(int Value)
            {
    
                if (Value > 95 && Value < 106)
                    return ((char)(Value-48)).ToString();
    
                if (Value > 64 && Value < 91)
                {if(!Control.IsKeyLocked(Keys.CapsLock))
                    return ((char)(Value+32)).ToString();
                else
                        return ((char)(Value)).ToString();
                }
                if (Value > 47 && Value < 58)
                    return ((char)Value).ToString();
                
    
                return null;
            }
