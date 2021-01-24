    /// <summary>
    /// Indicates whether session checking is enabled for an MVC action or controller.
    /// </summary>
    public class CheckSessionAttribute : Attribute
    {
        public CheckSessionAttribute(bool enabled)
        {
            this.Enabled = enabled;
        }
        public bool Enabled { get; }
    }
