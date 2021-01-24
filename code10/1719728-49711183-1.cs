    [Command("spamstring")]
        [Alias("sp", "spamming", "juanspam")]
        public async Task spamming(int times, string message)
        {
            //try and refrain from BIG if statements like this
            if (times > 68)
            {
                await Context.Message.DeleteAsync();
                await ReplyAsync(Context.User.Mention + " *YOU CANNOT GO OVER 69* :eggplant:");
            }
            else
            {
                await Context.Message.DeleteAsync();
                await ReplyAsync("You chose to spam " + times + " times, what do you want to spam?");
                //NEW IF
                if (message.ToString() == "@everyone")
                {
                    await ReplyAsync("Don't do that bitch. You deserve to be spammed for that!");
                }
                else
                {
                    await Context.Channel.SendMessageAsync(":fire: *SPAMMING* :fire: ");
                    
                    //spam loop
                    for (int i = 0; i < times; i++)
                    {
                        await Context.Channel.SendMessageAsync(message);
                        System.Threading.Thread.Sleep(1500);
                    }
                }
            }
           //END BIG OF
        }
    }
}
