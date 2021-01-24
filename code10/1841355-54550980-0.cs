    /// <summary>
    /// Behavior that will connect an UI event to a viewmodel Command,
    /// allowing the event arguments to be passed as the CommandParameter.
    /// </summary>
    public class EventToCommandBehavior : Behavior<FrameworkElement>
    {
        // Event
        public string Event
        {
            get { return ( string ) GetValue( EventProperty ); }
            set { SetValue( EventProperty, value ); }
        }
        public static readonly DependencyProperty EventProperty =
            DependencyProperty.Register( nameof( Event ), typeof( string ), typeof( EventToCommandBehavior ),
                new PropertyMetadata( null, OnEventChanged ) );
        // Command
        public ICommand Command
        {
            get { return ( ICommand ) GetValue( CommandProperty ); }
            set { SetValue( CommandProperty, value ); }
        }
        public static readonly DependencyProperty CommandProperty
            = DependencyProperty.Register( nameof( Command ), typeof( ICommand ), typeof( EventToCommandBehavior ), new PropertyMetadata( null ) );
        // PassArguments (default: false)
        public bool PassArguments
        {
            get { return ( bool ) GetValue( PassArgumentsProperty ); }
            set { SetValue( PassArgumentsProperty, value ); }
        }
        public static readonly DependencyProperty PassArgumentsProperty
            = DependencyProperty.Register( nameof( PassArguments ), typeof( bool ), typeof( EventToCommandBehavior ), new PropertyMetadata( false ) );
        protected override void OnAttached()
        {
            AttachHandler( Event ); // initial set
        }
        /// <summary>
        /// Attaches the handler to the event
        /// </summary>
        private void AttachHandler( string eventName )
        {
            // detach old event
            if ( oldEvent != null )
                oldEvent.RemoveEventHandler( AssociatedObject, handler );
            // attach new event
            if ( !string.IsNullOrEmpty( eventName ) )
            {
                EventInfo ei = AssociatedObject.GetType().GetEvent( eventName );
                if ( ei != null )
                {
                    MethodInfo mi = GetType().GetMethod( nameof( ExecuteCommand ), BindingFlags.Instance | BindingFlags.NonPublic );
                    if ( mi != null )
                    {
                        handler = Delegate.CreateDelegate( ei.EventHandlerType, this, mi );
                        ei.AddEventHandler( AssociatedObject, handler );
                        oldEvent = ei; // store to detach in case the Event property changes
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            $"Method {nameof( ExecuteCommand )} not found in class {nameof( EventToCommandBehavior )}" );
                    }
                }
                else
                {
                    throw new ArgumentException( $"The event '{eventName}' was not found on type '{AssociatedObject.GetType().Name}'" );
                }
            }
        }
        private static void OnEventChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            var beh = ( EventToCommandBehavior ) d;
            if ( beh.AssociatedObject != null ) // is not yet attached at initial load
                beh.AttachHandler( ( string ) e.NewValue );
        }
        /// <summary>
        /// Executes the Command
        /// </summary>
        // ReSharper disable once UnusedParameter.Local
        private void ExecuteCommand( object sender, EventArgs e )
        {
            object parameter = PassArguments ? e : null;
            if ( Command != null )
            {
                if ( Command.CanExecute( parameter ) )
                    Command.Execute( parameter );
            }
        }
        private Delegate handler;
        private EventInfo oldEvent;
    }
