        class CommandConfig
        {
            public int Lower { get; set; }
            public int Upper { get; set; }
            public Command Command { get; set; }
        }
        private static Dictionary<string, CommandConfig> m_dCommandFuncs2 = new Dictionary<string, CommandConfig>
        {
            {"foo", new CommandConfig {Lower = 1, Upper = 3, Command = CommandFoo}},
            {"bar", new CommandConfig {Lower = 2, Upper = 2, Command = CommandBar}}
        };
