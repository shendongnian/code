    public class MemberAssignmentService
    {
        private readonly ulong _roleId;
        public MemberAssignmentService(DiscordSocketClient client, ulong roleId)
        {
            // Hook the evnet
            client.UserJoined += AssignMemberAsync;
    
            // Note that we are using role identifier here instead
            // of name like your original solution; this is because
            // a role name check could easily be circumvented by a new role
            // with the exact name.
            _roleId = roleId;
        }
        
        private async Task AssignMemberAsync(SocketGuildUser guildUser)
        {
            var guild = guildUser.Guild;
            // Check if the desired role exist within this guild.
            // If not, we simply bail out of the handler.
            var role = guild.GetRole(_roleId);
            if (role == null) return;
            // Check if the bot user has sufficient permission
            if (!guild.CurrentUser.GuildPermissions.Has(GuildPermissions.ManageRoles)) return;
    
            // Finally, we call AddRoleAsync
            await guildUser.AddRoleAsync(role);
        }
    }
