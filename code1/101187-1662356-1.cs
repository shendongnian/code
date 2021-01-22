    /// <summary>
    /// Represents a fluent expression for handling keyboard event.
    /// </summary>
    public class KeyboardFluent
    {
        /// <summary>
        /// The control on which the fluent keyboard expression is occuring.
        /// </summary>
        private Control control;
        /// <summary>
        /// The KeyDown and KeyUp handler.
        /// </summary>
        private KeyEventHandler keyHandler;
        /// <summary>
        /// Stores if the IsDown method was called and that the KeyDown event is registered.
        /// </summary>
        private bool isDownRegistered = false;
        /// <summary>
        /// Stores if the IsUp method was called and that the KeyUp event is registered.
        /// </summary>
        private bool isUpRegistered = false;
        /// <summary>
        /// The list of keys that will make the actions be executed when they are down or up.
        /// </summary>
        private List<Keys> triggerKeys;
        /// <summary>
        /// The modifiers keys that must be down at the same time than the trigger keys for the actions to be executed.
        /// </summary>
        private Keys modifiers;
        /// <summary>
        /// The list of actions that will be executed when the trigger keys and modifiers are down or up.
        /// </summary>
        private List<Action<object, KeyEventArgs>> actions;
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardFluent"/> class.
        /// </summary>
        /// <param name="control">The control on which the fluent keyboard expression is occuring.</param>
        public KeyboardFluent(Control control)
        {
            this.control = control;
            this.triggerKeys = new List<Keys>();
            this.actions = new List<Action<object, KeyEventArgs>>();
            this.keyHandler = new KeyEventHandler(OnKeyHandler);
        }
        /// <summary>
        /// Handles the KeyDown or KeyUp event on the control.
        /// </summary>
        /// <param name="sender">The control on which the event is occuring.</param>
        /// <param name="e">A <see cref="KeyEventArgs"/> that gives information about the keyboard event.</param>
        private void OnKeyHandler(object sender, KeyEventArgs e)
        {
            if (this.triggerKeys.Contains(e.KeyCode) && e.Modifiers == this.modifiers)
            {
                this.actions.ForEach(action => action(sender, e));
            }
        }
        /// <summary>
        /// Makes the keyboard event occured when a key is pressed down.
        /// </summary>
        /// <returns>Returns itself to allow a fluent expression structure.</returns>
        public KeyboardFluent IsDown()
        {
            if (!isDownRegistered)
            {
                this.control.KeyDown += this.keyHandler;
                isDownRegistered = true;
            }
            return this;
        }
        /// <summary>
        /// Makes the keyboard event occured when a key is pressed up.
        /// </summary>
        /// <returns>Returns itself to allow a fluent expression structure.</returns>
        public KeyboardFluent IsUp()
        {
            if (!isUpRegistered)
            {
                this.control.KeyUp += this.keyHandler;
                isUpRegistered = true;
            }
            return this;
        }
        /// <summary>
        /// Creates a new trigger on a key.
        /// </summary>
        /// <param name="key">The key on which the actions will occur.</param>
        /// <returns>Returns itself to allow a fluent expression structure.</returns>
        public KeyboardFluent When(Keys key)
        {
            this.triggerKeys.Add(key);
            return this;
        }
        /// <summary>
        /// Adds a modifier filter that is checked before the action are executed.
        /// </summary>
        /// <param name="modifiers">The modifier key.</param>
        /// <returns>Returns itself to allow a fluent expression structure.</returns>
        public KeyboardFluent With(Keys modifiers)
        {
            this.modifiers |= modifiers;
            return this;
        }
        /// <summary>
        /// Executes the action when the specified keys and modified are either pressed down or up.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        /// <returns>Returns itself to allow a fluent expression structure.</returns>
        public KeyboardFluent Do(Action<object, KeyEventArgs> action)
        {
            this.actions.Add(action);
            return this;
        }
    }
