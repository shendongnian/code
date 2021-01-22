    public class CommandManager: Component
    {
        private IList<ICommand> Commands { get; set; }
        private IList<ICommandBinder> Binders { get; set; }
 
        public CommandManager()
        {
            Commands = new List<ICommand>();
 
            Binders = new List<ICommandBinder>
                          {
                              new ControlBinder(),
                              new MenuItemCommandBinder()
                          };
 
            Application.Idle += UpdateCommandState;
        }
 
        private void UpdateCommandState(object sender, EventArgs e)
        {
            Commands.Do(c => c.Enabled);
        }
 
        public CommandManager Bind(ICommand command, IComponent component)
        {
            if (!Commands.Contains(command))
                Commands.Add(command);
 
            FindBinder(component).Bind(command, component);
            return this;
        }
 
        protected ICommandBinder FindBinder(IComponent component)
        {
            var binder = GetBinderFor(component);
 
            if (binder == null)
                throw new Exception(string.Format("No binding found for component of type {0}", component.GetType().Name));
             
            return binder;
        }
 
        private ICommandBinder GetBinderFor(IComponent component)
        {
            var type = component.GetType();
            while (type != null)
            {
                var binder = Binders.FirstOrDefault(x => x.SourceType == type);
                if (binder != null)
                    return binder;
 
                type = type.BaseType;
            }
 
            return null;
        }
 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Application.Idle -= UpdateCommandState;
            
            base.Dispose(disposing);
        }
    }
 
    public static class Extensions
    {
        public static void Do<T>(this IEnumerable<T> @this, Func<T, object> lambda)
        {
            foreach (var item in @this)
                lambda(item);
        }
    }
    public abstract class CommandBinder<T> : ICommandBinder where T: IComponent
    {
        public Type SourceType
        {
            get { return typeof (T); }
        }
 
        public void Bind(ICommand command, object source)
        {
            Bind(command, (T) source); 
        }
 
        protected abstract void Bind(ICommand command, T source);
    }
  
    public class ControlBinder: CommandBinder<Control>
    {
        protected override void Bind(ICommand command, Control source)
        {
            source.DataBindings.Add("Enabled", command, "Enabled");
            source.DataBindings.Add("Text", command, "Name");
            source.Click += (o, e) => command.Execute();
        }
    }
 
    public class MenuItemCommandBinder : CommandBinder<ToolStripItem>
    {
        protected override void Bind(ICommand command, ToolStripItem source)
        {
            source.Text = command.Name;
            source.Enabled = command.Enabled;
            source.Click += (o, e) => command.Execute();
 
            command.PropertyChanged += (o, e) => source.Enabled = command.Enabled;
        }
    }
