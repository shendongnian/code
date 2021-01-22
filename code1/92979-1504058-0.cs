    public void CheckSpellingRec(IEnumerable<Control> controls)
    {
    	foreach(var c in controls)
    	{
    		if(c is MemoExEdit && c.Text != String.Empty)
    		{
    			//check spelling
    			control.BackColor = Color.FromArgb(180, 215, 195);
    			control.Text = HUD.Spelling.CheckSpelling(control.Text);
    			control.ResetBackColor();
    		}
    		
    		//check spelling of child controls
    		CheckSpellingRec(c.Controls.Cast<Control>());
    	}
    }
    
    public void CheckSpelling(Control parent)
    {
    	CheckSpellingRec(new[] { parent });
    }
