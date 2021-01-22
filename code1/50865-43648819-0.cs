    parentObject.SizeChanged += (sender, args) =>
    {
       if (textBox1.Text.Length > 0)
       {
           int maxSize = 100;
           // Make a Graphics object to measure the text.
           using (Graphics gr = textBox1.CreateGraphics())
           {
                for (int i = 1; i <= maxSize; i++)
                {
                     using (var test_font = new Font(textBox1.Font.FontFamily, i))
                       {
                            // See how much space the text would
                            // need, specifying a maximum width.
                            SizeF text_size =
                                        TextRenderer.MeasureText(
                                            textBox1.Text,
                                            test_font,
                                            new Size(textBox1.Width, int.MaxValue),
                                            TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                                    try
                                    {
                                        if (text_size.Height > textBox1.Height)
                                        {
                                            maxSize = i - 1;
                                            break;
                                        }
                                    }
                                    catch (System.ComponentModel.Win32Exception)
                                    {
                                        // this sometimes throws a "failure to create window handle" error.
                                        // This might happen if the TextBox is invisible and/or
                                        // too small to display a toolbar.
                                        // do whatever here, add/delete, whatever, maybe set to default font size?
                                        maxSize = (int) textBox1.Font.Size;
                                    }
                                }
                            }
                        }
                        // Use that font size.
                        textBox1.Font = new Font(textBox1.Font.FontFamily, maxSize);
                    }
                };
