                //If still bigger, set scrollbars:
                
                if ((Output.Document.Body.ScrollRectangle.Size.Height > Output.Size.Height) ||
                    Output.Document.Body.ScrollRectangle.Size.Width > Output.Size.Width)
                {
                    ScrollPanel.Visible = false;
                    ScrollPanel.Enabled = false;
                }
