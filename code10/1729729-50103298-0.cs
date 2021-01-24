        public class MyTabControl : TabControl
         {
             static MyTabControl()
             {
                 DefaultStyleKeyProperty.OverrideMetadata(typeof(MyTabControl), new FrameworkPropertyMetadata(typeof(MyTabControl)));
             }
             public static readonly DependencyProperty TabChangedCommandProperty = DependencyProperty.Register(
                 "TabChangedCommand", typeof(ICommand), typeof(MyTabControl), 
                 new PropertyMetadata((ICommand)null,
                 new PropertyChangedCallback(CommandCallBack)));
             private static void CommandCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
             {
                 var myTabControl = (MyTabControl)d;
                 myTabControl.HookupCommands((ICommand) e.OldValue, (ICommand) e.NewValue);
             }
             private void HookupCommands(ICommand oldValue, ICommand newValue)
             {
                if (oldValue != null)
                 {
                     RemoveCommand(oldValue, oldValue);
                 }
                 AddCommand(oldValue, oldValue);
             }
             private void AddCommand(ICommand oldValue, ICommand newCommand)
             {
                 EventHandler handler = new EventHandler(CanExecuteChanged);
                 var canExecuteChangedHandler = handler;
                 if (newCommand != null)
                 {
                     newCommand.CanExecuteChanged += canExecuteChangedHandler;
                 }
            
             }
             private void CanExecuteChanged(object sender, EventArgs e)
             {
                 if (this.TabChangedCommand != null)
                 {
                     if (TabChangedCommand.CanExecute(null))
                     {
                         this.IsEnabled = true;
                     }
                     else
                     {
                         this.IsEnabled = false;
                     }
                 }
             }
             private void RemoveCommand(ICommand oldCommand, ICommand newCommand)
             {
                 EventHandler handler = CanExecuteChanged;
                 oldCommand.CanExecuteChanged -= handler;
             }
             public ICommand TabChangedCommand
             {
                 get { return (ICommand) GetValue(TabChangedCommandProperty); }
                 set { SetValue(TabChangedCommandProperty, value); }
             }
       
             public override void OnApplyTemplate()
             {
                 base.OnApplyTemplate();
                 this.SelectionChanged += OnSelectionChanged;
             }
             private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
             {
                 if (TabChangedCommand != null)
                 {
                     TabChangedCommand.Execute(null);
                 }
             }
             }
