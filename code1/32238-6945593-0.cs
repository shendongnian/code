    public abstract class Entity
    {
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return this is IHasDescription
                       ? ((IHasDescription) this).EntityDescription
                       : base.ToString();
        }
    }
