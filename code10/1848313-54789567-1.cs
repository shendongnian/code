        /// <summary>
        /// Get the mime content for an email just sent
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
	    public byte[] GetJustSentMimeContent(string messageId)
	    {
	        ExchangeService exchangeService = ExchangeService;
	        // Use the following search filter to get mail with TempEmailId set to what we just got
	        var searchCriteria = new SearchFilter.IsEqualTo(_TempEmailId, messageId);
	        var itemView = new ItemView(1) {PropertySet = new PropertySet(BasePropertySet.IdOnly)};
	        byte[] GetMimeContent(WellKnownFolderName folder)
	        {
	            var items = exchangeService.FindItems(folder, searchCriteria, itemView);
	            if (items.TotalCount > 0)
	            {
	                // if it's still in there, try and load the properties for it
	                exchangeService.LoadPropertiesForItems(items,
	                    new PropertySet(BasePropertySet.IdOnly,
	                        ItemSchema.MimeContent));
	                var emailMessage = (EmailMessage) items.First();
	                // if the content has been loaded, return it
	                if (emailMessage.MimeContent != null)
	                    return emailMessage.MimeContent.Content;
	            }
	            return null;
	        }
	        // check the drafts folder to see if it's still in there
	        var mimeContent = GetMimeContent(WellKnownFolderName.Drafts);
	        if (mimeContent != null)
	            return mimeContent;
	        // if at this point, either: 
	        // - email was moved to SentItems before the first search was done
	        // - or email was found in Drafts but then moved to SentItems but before the MimeContent could be loaded. Need to restart the process and find the email in SentItems instead
	        // should be in here (sentItems) now, try and load the properties for it
	        return GetMimeContent(WellKnownFolderName.SentItems);
	    }
