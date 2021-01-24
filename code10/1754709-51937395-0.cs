        protected enum customCommands
        {
            install = 128,
            uninstall = 129,
        }
        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);
            if (command >= 128 && command <= 255)
            {
                customCommands cust = (customCommands)command;
                switch (cust)
                {
                    case customCommands.install:
                        break;
                    case customCommands.uninstall:
                        break;
                    default:
                        break;
                }
            }
        }
