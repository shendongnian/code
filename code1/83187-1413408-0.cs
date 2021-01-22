            private System.Windows.Forms.RichTextBox richTextBox3;
            try
            {
                this.richTextBox3 = new Microsoft.Ink.InkEdit();
                Microsoft.Ink.InkEdit ie = (Microsoft.Ink.InkEdit)richTextBox3;
                // disable tablet-style ink mode
                ie.InkMode = Microsoft.Ink.InkMode.Disabled;
            }
            catch
            {
                \\ in case platform does not support inkedit control
                this.richTextBox3 = new RichTextBox();
            }
