        [Command("warn")]
        public async Task WarnPlayer(SocketUser user = null)
        {
            if (user != null)
            {
            Dictionary<string, uint> PlayerWarnings = JsonConvert
                .DeserializeObject<Dictionary<string, uint>>(File.ReadAllText(warningText));
            PlayerWarnings.Add(user.Username, 1);
            PlayerWarnings.TryGetValue(user.Username, out uint warningNum);
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithDescription
                    ($"{user.Username} has been given a warning. They now have {warningNum}")
                .WithColor(Color.Gold)
                .WithThumbnailUrl(user.GetAvatarUrl());
            await ReplyAsync("", false, builder.Build());
            }
            else
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithDescription
                        ($"Please select a user to warn.")
                    .WithColor(Color.Red)
                    .WithThumbnailUrl(user.GetAvatarUrl());
                await ReplyAsync("", false, builder.Build());
            }
        }
