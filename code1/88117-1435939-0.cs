    /// <summary>
    /// Builds Includes
    /// </summary>
    public class IncludeBuilder
    {
        /// <summary>
        /// List of parts for the Include
        /// </summary>
        private List<string> Parts;
        /// <summary>
        /// Creates a new IncludeBuilder
        /// </summary>
        private IncludeBuilder()
        {
            this.Parts = new List<string>();
        }
        /// <summary>
        /// Creates a new IncludeBuilder
        /// </summary>
        public static IncludeBuilder Create()
        {
            return new IncludeBuilder();
        }
        /// <summary>
        /// Adds a property name to the builder
        /// </summary>
        public IncludeBuilder AddPart<TEntity, TProp>(Expression<Func<TEntity, TProp>> expression)
        {
            string propName = ExpressionHelper.GetPropertyNameFromExpression(expression);
            this.Parts.Add(propName);
            return this;
        }
        /// <summary>
        /// Gets a value of the include parts separated by
        /// a decimal
        /// </summary>
        public override string ToString()
        {
            return string.Join(".", this.Parts.ToArray());
        
        }
