    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for starting a fluent expression on a <see cref="System.Windows.Form.Control"/> object.
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Starts a fluent expression that occurs when a key is pressed.
        /// </summary>
        /// <param name="control">The control on which the fluent keyboard expression is occuring.</param>
        /// <param name="keys">The key when it will happen.</param>
        /// <returns>A <see cref="KeyboardFluent"/> object that makes it possible to write a fluent expression.</returns>
        public static KeyboardFluent When(this Control control, Keys keys)
        {
            return new KeyboardFluent(control).When(keys);
        }
    }
