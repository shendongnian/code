    [Command("spawn"), Summary("Spawn a monster")]
    public async Task Embed()
    {
                RestUserMessage picture = await Context.Channel.SendFileAsync(@"Resources\test.png");
                string imgurl = picture.Attachments.First().Url;
                await Context.Channel.SendMessageAsync("", false, new EmbedBuilder { Title = "Test", Description = "Test", Color = new Color(0,255,0), ImageUrl = imgurl }.Build());
                await picture.DeleteAsync();
            }
