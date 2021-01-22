    public interface ICommandProperty<T, U>
        {
            Func<T> CreateCommand { get; set; }
            Func<T, U> ParseResponse { get; set; }
        }
    
        public interface IDeviceCommand
        {
    
            void SetCreateCommand<T, U>(Func<ICommandProperty<T, U>> cmd);
            void SetParseCommand<T, U>(Func<ICommandProperty<T, U>> cmd);
    
            Func<ICommandProperty<T, U>> GetCreateCommand<T, U>();
            Func<ICommandProperty<T, U>> GetParseCommand<T, U>();
    
            void Create(object someKnownObject);
            T Parse<T>(object someKnownObject);
    
            string Name { get; set; }
        }
    
        public class DeviceCommand : IDeviceCommand
        {
            public DeviceCommand(IDeviceCommandBuilder builder)
            {
                builder.SetCommands(this);
            }
    
    
            public void SetCreateCommand<T, U>(Func<ICommandProperty<T, U>> cmd)
            {
                throw new NotImplementedException();
            }
    
            public void SetParseCommand<T, U>(Func<ICommandProperty<T, U>> cmd)
            {
                throw new NotImplementedException();
            }
    
            public Func<ICommandProperty<T, U>> GetCreateCommand<T, U>()
            {
                throw new NotImplementedException();
            }
    
            public Func<ICommandProperty<T, U>> GetParseCommand<T, U>()
            {
                throw new NotImplementedException();
            }
    
            public void Create(object someKnownObject)
            {
                throw new NotImplementedException();
            }
    
            public T Parse<T>(object someKnownObject)
            {
                throw new NotImplementedException();
            }
    
            public string Name
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }
    
        public interface IDeviceCommandBuilder
        {
            void SetCommands(IDeviceCommand command);
        }
    
        public class DeviceCommandBuilder : IDeviceCommandBuilder
        {
            public void SetCommands(IDeviceCommand command)
            {
                command.SetCreateCommand<string,Uri>(.)
                ;
                command.SetParseCommand(.);
            }
        }
