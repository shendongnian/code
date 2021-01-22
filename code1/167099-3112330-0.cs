        /// <summary>
        /// Wrapper for command objects, created for convenience to simplify ViewModel code
        /// </summary>
        /// <author>Ben Schoepke</author>
        public class CommandWrapper
        {
        private readonly List<DelegateCommand<object>> _commands; // cache all commands as needed
        /// <summary>
        /// </summary>
        public CommandWrapper()
        {
            _commands = new List<DelegateCommand<object>>();
        }
        /// <summary>
        /// Returns the ICommand object that contains the given delegates
        /// </summary>
        /// <param name="executeMethod">Defines the method to be called when the command is invoked</param>
        /// <param name="canExecuteMethod">Defines the method that determines whether the command can execute in its current state.
        /// Pass null if the command should always be executed.</param>
        /// <returns>The ICommand object that contains the given delegates</returns>
        /// <author>Ben Schoepke</author>
        public ICommand GetCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
        {
            // Search for command in list of commands
            var command = (_commands.Where(
                                cachedCommand => cachedCommand.ExecuteMethod.Equals(executeMethod) &&
                                                 cachedCommand.CanExecuteMethod.Equals(canExecuteMethod)))
                                                 .FirstOrDefault();
            // If command is found, return it
            if (command != null)
            {
                return command;
            }
            // If command is not found, add it to the list
            command = new DelegateCommand<object>(executeMethod, canExecuteMethod);
            _commands.Add(command);
            return command;
        }
    }
