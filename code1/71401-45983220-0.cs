	public class TextBoxEx : TextBox
	{
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// Attention:
			// Similar code exists in ComboBoxEx.ProcessCmdKey().
			// Changes here may have to be applied there too.
			if (ShortcutsEnabled)
			{
				if (keyData == (Keys.Control | Keys.Back))
				{
					if (!ReadOnly)
					{
						if (SelectionStart > 0)
						{
							int i = (SelectionStart - 1);
							// Potentially trim white space:
							if (char.IsWhiteSpace(Text, i))
								i = (StringEx.StartIndexOfSameCharacterClass(Text, i) - 1);
							// Find previous marker:
							if (i > 0)
								i = StringEx.StartIndexOfSameCharacterClass(Text, i);
							else
								i = 0; // Limit i as it may become -1 on trimming above.
							// Remove until previous marker or the beginning:
							Text = Text.Remove(i, SelectionStart - i);
							SelectionStart = i;
							return (true);
						}
						else
						{
							return (true); // Ignore to prevent a white box being placed.
						}
					}
				}
				else if (keyData == (Keys.Control | Keys.A))
				{
					if (!ReadOnly && Multiline)
					{
						SelectAll();
						return (true);
					}
				}
			}
			return (base.ProcessCmdKey(ref msg, keyData));
		}
	}
