    public static ulong GetWhitelisted(string key)
    {
        if (whitelisted.ContainsKey(MinecraftClient.ChatBots.WeeWoo.username))
        {
            ulong userWhiteListId;
            if (UInt64.TryParse(key, out userWhiteListId))
            {
                // If parsing succeeded, return the value
                return userWhiteListId;
            }
            // Optionally, return some other value if the user was found but parsing failed
            // return -1;
        }
        // Either the user wasn't found or the parsing failed
        return 0;
    }
