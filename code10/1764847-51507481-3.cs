      [ComVisible(true)]
      public class KeyPressEventArgs : EventArgs
      {
        ...
        /// <summary>Gets or sets the character corresponding to the key pressed.</summary>
        /// <returns>The ASCII character that is composed. For example, if the user presses SHIFT + K, this property returns an uppercase K.</returns>
        public char KeyChar { get; set; }
        ...
      }
