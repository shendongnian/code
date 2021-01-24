    public bool IsFromGuildChat()
    {
         var IsFromGuildChat = Context.Guild.Id != 0;
         if (IsFromGuildChat == false)
             throw new RequiresDiscordGuildException(); //custom exception 
          return IsFromGuildChat;
    }
