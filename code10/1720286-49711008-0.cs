    public class HandlerCache
    {
        private readonly Dictionary<Type, HandlerDelegate> handlers = new
            Dictionary<Type, HandlerDelegate>();
        public void AddHandler(Action<T> action) where T : ICommand =>
            handlers.Add(typeof(T), command => action((T) command);
      
        public void HandleCommand(ICommand command)
        {
            var commandType = command.GetType();
            if (!handlers.TryGetValue(commandType, out var handler))
            {
                throw new ArgumentException($"Unable to handle commands of type {commandType}");
            }
            handler(command);
        }
    }
