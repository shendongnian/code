    				foreach (var Folder in _service.FindFolders(WellKnownFolderName.Inbox, filter, view))
				{					
					MessageBox.Show(Folder.DisplayName);
					
					foreach (EmailMessage email in Folder.FindItems(fileview))
					{
						email.Load(new PropertySet(EmailMessageSchema.ConversationTopic, ItemSchema.Attachments,
							ItemSchema.TextBody));
						MessageBox.Show(email.ConversationTopic);
						MessageBox.Show(email.TextBody);
					}
				}
