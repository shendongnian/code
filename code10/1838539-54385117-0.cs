    foreach (var user in users)
                {
                    var u = user as IGuildUser;
    
                    if (!u.IsBot && !u.IsWebhook)
                    {
                        try
                        {
                            await u.SendMessageAsync("Hi");
                        }
                        catch (Exception e)
                        {
                            var useless = e;
                        }
                    }
                }
