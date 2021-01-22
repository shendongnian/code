       class MyMaskedTextbox : MaskedTextBox
        	{
        		const int WM_PASTE = 0x0302;
        
        		protected override void WndProc(ref Message m)
        		{
        			switch (m.Msg)
        			{
        				case WM_PASTE:
        					if (Clipboard.ContainsText())
        					{
        						string text = Clipboard.GetText();
        						text = text.Replace(' ', '-');
    //put your processing here
        						Clipboard.SetText(text);
        					}
        					break;
        			}
        			base.WndProc(ref m);
        		}
        	}
