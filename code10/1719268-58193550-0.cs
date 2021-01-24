     private async Task Announce(ExampleType object) //1
            {
                ulong id = object.GuildId; // 3
                var chnl = client.GetChannel(object.ChannelId) as IMessageChannel; // 4
                await chnl.SendMessageAsync("Message!"); // 5
            }
