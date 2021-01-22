				public static void Set(this RichTextBox rtb, Font font, string text)
			{
					
        		rtb.Text = text;
				rtb.SelectAll();
        		rtb.SelectionFont = font;
            		rtb.SelectionIndent = 12;
                     return rtb;
			}
