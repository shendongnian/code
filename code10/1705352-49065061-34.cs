    public class SystemMenu
    {
        #region Native methods
        private const int WM_SYSCOMMAND = 0x112;
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, MenuItemInfo_fType uFlags, int uIDNewItem, string lpNewItem);
        #endregion Native methods
        #region Private data
        public enum CommandType : int
        {
            AppendMenu = 0,
            InesertMenu
        }
        private MenuItemInfo_fMask InsMenuFlags = MenuItemInfo_fMask.MIIM_STRING |
                                                  MenuItemInfo_fMask.MIIM_BITMAP |  
                                                  MenuItemInfo_fMask.MIIM_FTYPE | 
                                                  MenuItemInfo_fMask.MIIM_STATE | 
                                                  MenuItemInfo_fMask.MIIM_ID;
        private Form form;
        private IntPtr hSysMenu;
        private int lastId = 0;
        private List<Action> actions = new List<Action>();
        private List<CommandInfo> pendingCommands;
        #endregion Private data
        #region Constructors
        /// <summary>
        /// Initialises a new instance of the <see cref="SystemMenu"/> class for the specified
        /// <see cref="Form"/>.
        /// </summary>
        /// <param name="form">The window for which the system menu is expanded.</param>
        public SystemMenu(Form form)
        {
            this.form = form;
            if (!form.IsHandleCreated)
            {
                form.HandleCreated += OnHandleCreated;
            }
            else
            {
                OnHandleCreated(null, null);
            }
        }
        #endregion Constructors
        #region Public methods
        /// <summary>
        /// Adds a command to the system menu.
        /// </summary>
        /// <param name="text">The displayed command text.</param>
        /// <param name="action">The action that is executed when the user clicks on the command.</param>
        /// <param name="separatorBeforeCommand">Indicates whether a separator is inserted before the command.</param>
        public void AddCommand(string text, Action action, bool separatorBeforeCommand)
        {
            int id = ++lastId;
            if (!form.IsHandleCreated)
            {
                // The form is not yet created, queue the command for later addition
                if (pendingCommands == null)
                {
                    pendingCommands = new List<CommandInfo>();
                }
                pendingCommands.Add(new CommandInfo
                {
                    Id = id,
                    Text = text,
                    Action = action,
                    CommandType = SystemMenu.CommandType.AppendMenu,
                    Separator = separatorBeforeCommand
                });
            }
            else
            {
                // The form is created, add the command now
                if (separatorBeforeCommand)
                {
                    AppendMenu(hSysMenu, MenuItemInfo_fType.MFT_SEPARATOR, 0, "");
                }
                AppendMenu(hSysMenu, MenuItemInfo_fType.MFT_SEPARATOR, id, text);
            }
            actions.Add(action);
        }
        /// <summary>
        /// Adds a command to the system menu.
        /// </summary>
        /// <param name="icText">The displayed command text.</param>
        /// <param name="icAction">The action that is executed when the user clicks on the command.</param>
        /// <param name="separatorBeforeCommand">Indicates whether a separator is inserted before the command.</param>
        public void InsertCommand(uint icIndex, string icText, IntPtr hBitmap, Action icAction)
        {
            int id = ++lastId;
            InsertCommand(id, icIndex, icText, hBitmap, icAction);
        }
        private void InsertCommand(int id, uint icIndex, string icText, IntPtr hBitmap, Action icAction)
        {
            if (!form.IsHandleCreated)
            {
                // The form is not yet created, queue the command for later addition
                if (pendingCommands == null)
                {
                    pendingCommands = new List<CommandInfo>();
                }
                pendingCommands.Add(new CommandInfo
                {
                    Id = id,
                    Index = (int)icIndex,
                    Text = icText,
                    Action = icAction,
                    CommandType = SystemMenu.CommandType.InesertMenu,
                    hBitmap = hBitmap,
                    Separator = false
                });
            }
            else
            {
                MenuItemInfo mInfo = new MenuItemInfo()
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(MenuItemInfo)),
                    fMask = InsMenuFlags,
                    fType = MenuItemInfo_fType.MFT_STRING,
                    fState = MenuItemInfo_fState.MFS_ENABLED,
                    wID = (uint)id,
                    hbmpItem = hBitmap,
                    hbmpChecked = hBitmap,
                    hbmpUnchecked = hBitmap,
                    dwTypeData = Marshal.StringToHGlobalAuto(icText),
                    dwItemData = IntPtr.Zero,
                    hSubMenu = IntPtr.Zero,
                    cch = (uint)icText.Length,
                };
                // The form is created, add the command now
                InsertMenuItem(hSysMenu, icIndex, true, ref mInfo);
            }
            actions.Add(icAction);
        }
        
        /// <summary>
        /// Tests a window message for system menu commands and executes the associated action. This
        /// method must be called from within the Form's overridden WndProc method because it is not
        /// publicly accessible.
        /// </summary>
        /// <param name="msg">The window message to test.</param>
        public void HandleMessage(ref Message msg)
        {
            // This method is kept short and simple to allow inlining (verified) for improving
            // performance (unverified). It will be called for every single message that is sent to
            // the window.
            if (msg.Msg == WM_SYSCOMMAND)
            {
                OnSysCommandMessage(ref msg);
            }
        }
        #endregion Public methods
        #region Private methods
        private void OnHandleCreated(object sender, EventArgs args)
        {
            form.HandleCreated -= OnHandleCreated;
            hSysMenu = GetSystemMenu(form.Handle, false);
            // Add all queued commands now
            if (pendingCommands != null)
            {
                foreach (CommandInfo command in pendingCommands)
                {
                    switch (command.CommandType)
                    {
                        case CommandType.AppendMenu:
                            if (command.Separator) {
                                AppendMenu(hSysMenu, MenuItemInfo_fType.MFT_SEPARATOR, 0, "");
                            }
                            AppendMenu(hSysMenu, MenuItemInfo_fType.MFT_STRING, command.Id, command.Text);
                            break;
                        case CommandType.InesertMenu:
                            InsertCommand(command.Id, (uint)command.Index, command.Text, command.hBitmap, command.Action);
                            break;
                        default:
                            break;
                    }
                }
                pendingCommands = null;
            }
        }
        private void OnSysCommandMessage(ref Message msg)
        {
            if ((long)msg.WParam > 0 && (long)msg.WParam <= lastId)
            {
                actions[(int)msg.WParam - 1]();
            }
        }
        #endregion Private methods
        #region Classes
        private class CommandInfo
        {
            public int Id { get; set; }
            public int Index { get; set; }
            public string Text { get; set; }
            public Action Action { get; set; }
            public IntPtr hBitmap { get; set; }
            public bool Separator { get; set; }
            public CommandType CommandType { get; set; }
        }
        #endregion Classes
    }
