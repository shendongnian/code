     private async Task Announce(ExampleType object) //1
            {
                ulong id = object.ChannelId; // 3
                var chnl = client.GetChannel(id) as IMessageChannel; // 4
                await chnl.SendMessageAsync("Message!"); // 5
            }
