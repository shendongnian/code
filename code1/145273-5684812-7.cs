		internal void ExecuteCommandDocument(string command, bool prompt)
		{
			try
			{
				// ensure command is a valid command and then enabled for the selection
				if (document.queryCommandSupported(command))
				{
                    if (command == HTML_COMMAND_TEXT_PASTE && Clipboard.ContainsImage())
                    {
                        // Save image to user temp dir
                        String imagePath = Path.GetTempPath() + "\\" + Path.GetRandomFileName() + ".jpg";
                        Clipboard.GetImage().Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        // Insert image href in to html with temp path
                        Uri uri = null;
                        Uri.TryCreate(imagePath, UriKind.Absolute, out uri);
                        document.execCommand(HTML_COMMAND_INSERT_IMAGE, false, uri.ToString());
                        // Update pasted id
                        Guid elementId = Guid.NewGuid();
                        GetFirstControl().id = elementId.ToString();
                        // Fire event that image saved to any interested listeners who might want to save it elsewhere as well
                        if (OnImageInserted != null)
                        {
                            OnImageInserted(this, new ImageInsertEventArgs { HrefUrl = uri.ToString(), TempPath = imagePath, HtmlElementId = elementId.ToString() });
                        }
                    }
                    else
                    {
                        // execute the given command
                        document.execCommand(command, prompt, null);
                    }
				}
			}
			catch (Exception ex)
			{
				// Unknown error so inform user
				throw new HtmlEditorException("Unknown MSHTML Error.", command, ex);
			}
		}
