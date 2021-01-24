    [Command("stream")]
    public async Task RoleTask()
    {
        ulong roleId = 486599202093269012;
        var role = Context.Guild.GetRole(roleId);
        await ((SocketGuildUser) Context.User).AddRoleAsync(role);
    }
