    /// <summary>
            /// Handles the KeyDown event of the richTextBoxConsole control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
            void richTextBoxConsole_KeyDown(object sender, KeyEventArgs e)
            {
                bool inReadOnlyZone = richTextBoxConsole.Selection.Start.CompareTo(inputStart) < 0;
    
                //  If we're at the input point and it's backspace, bail.
                if (inReadOnlyZone && e.Key == Key.Back)
                    e.Handled = true;;
    
                //  Are we in the read-only zone?
                if (inReadOnlyZone)
                {
                    //  Allow arrows and Ctrl-C.
                    if (!(e.Key == Key.Left ||
                        e.Key == Key.Right ||
                        e.Key == Key.Up ||
                        e.Key == Key.Down ||
                        (e.Key == Key.C && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))))
                    {
                        e.Handled = true;
                    }
                }
    
                //  Is it the return key?
                if (e.Key == Key.Return)
                {
                    //  Get the input.
                    //todostring input = richTextBoxConsole.Text.Substring(inputStart, (richTextBoxConsole.SelectionStart) - inputStart);
    
                    //  Write the input (without echoing).
                    //todoWriteInput(input, Colors.White, false);
                }
            }
