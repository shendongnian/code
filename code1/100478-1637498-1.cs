            // Create a temporary buffer - using a RichTextBox instead
            // of a string will keep the RTF formatted correctly
            using (RichTextBox buffer = new RichTextBox())
            {
                // Split the text into lines
                string[] lines = this.richTextBox1.Lines;
                int start = 0;
                // Iterate the lines
                foreach (string line in lines)
                {
                    // Ignore empty lines
                    if (line != String.Empty)
                    {
                        // Find the start position of the current line
                        start = this.richTextBox1.Find(line, start, RichTextBoxFinds.None);
                        // Select the line (not including new line, paragraph etc)
                        this.richTextBox1.Select(start, line.Length);
                        // Append the selected RTF to the buffer
                        buffer.SelectedRtf = this.richTextBox1.SelectedRtf;
                        // Move the cursor to the end of the buffers text for the next append
                        buffer.Select(buffer.TextLength, 0);
                    }
                }
                // Set the rtf of the original control
                this.richTextBox1.Rtf = buffer.Rtf;
            }
