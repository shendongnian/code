				DirectoryEntry adsEntry = new DirectoryEntry(path, strAccountId, strPassword);
				DirectorySearcher adsSearcher = new DirectorySearcher( adsEntry );
				//adsSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
				adsSearcher.Filter = "(sAMAccountName=" + strAccountId + ")";
				try 
				{
					SearchResult adsSearchResult = adsSearcher.FindOne();
					bSucceeded = true;
					
					strAuthenticatedBy = "Active Directory";
					strError = "User has been authenticated by Active Directory.";
					adsEntry.Close();
				}
				catch ( Exception ex )
				{
					// Failed to authenticate. Most likely it is caused by unknown user
					// id or bad strPassword.
					strError = ex.Message;
					adsEntry.Close();
				}
