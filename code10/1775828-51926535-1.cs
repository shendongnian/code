    public static Message ModifyMessage(GmailService service, String userId,
          String messageId, List<String> labelsToAdd, List<String> labelsToRemove)
      {
          ModifyMessageRequest mods = new ModifyMessageRequest();
          mods.RemoveLabelIds = "UNREAD";
    
          try
          {
              return service.Users.Messages.Modify(mods, userId, messageId).Execute();
          }
          catch (Exception e)
          {
              Console.WriteLine("An error occurred: " + e.Message);
          }
    
          return null;
      }
