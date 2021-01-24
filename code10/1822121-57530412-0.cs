            var GuildUser = Context.Guild.GetUser(Context.User.Id);
            if (!GuildUser.GuildPermissions.KickMembers)
            {
                await Context.Message.DeleteAsync();
                await ReplyAsync(":warning: `No permissions to kick players`");
                return;
            }
            else
            {
                await user.KickAsync();
                await Context.Channel.SendMessageAsync($":eye: `{user.Username} has been kicked from the server`");
                var guild = Context.Guild;
                var channel = guild.GetTextChannel(609086251978457098); //582790350620327952
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithTitle("Logged Information")
                    .AddField("User", $"{user.Mention}")
                    .AddField("Moderator", $"{Context.User.Username}")
                    .AddField("Other Information", "Can be invited back")
                    .AddField("Command", $"``.kick {user.Username}``")
                    .WithDescription($"This player has been kicked from {Context.Guild.Name} by {Context.User.Username}")
                    .WithFooter($"{Context.User.Username}", Context.User.GetAvatarUrl())
                    .WithCurrentTimestamp()
                    .WithColor(new Color(54, 57, 62));
            }
        }
