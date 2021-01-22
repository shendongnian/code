            private void CheckFormatting ()
			{
				StringReader objReaderf = new StringReader (txtInput.Text);
				List<String> formatTextList = new List<String> ();
				
				do {
					formatTextList.Add (objReaderf.ReadLine ());
				} while (objReaderf.Peek () != -1);
				
				objReaderf.Close ();
				
				bool testSucceed = true;
				for (int i = 0; i < formatTextList.Count; i++) {
					if (!Regex.IsMatch (formatTextList[i], "G[0-9]{2}:[0-9]{2}:[0-9]{2}:[0-9]{2} JG[0-9]{2}")) {
						MessageBox.Show ("Line " + formatTextList[i] + " is not formatted correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						testSucceed = false;
						break;
					}
				}
				
				if (testSucceed) {
					this.WriteToFile ();
					MessageBox.Show ("Your entries have been saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
