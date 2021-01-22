    public class PartBuilder
    {
        private List<string> Parts;
        /// <summary>
        /// Gets a dot delimited string representing the parts
        /// </summary>
        public string Value
        {
            get
            {
                return string.Join(".", this.Parts.ToArray());
            }
        }
        /// <summary>
        /// Creates a new PartBuilder
        /// </summary>
        private PartBuilder()
        {
            this.Parts = new List<string>();
        }
        /// <summary>
        /// Creates a new PartBuilder
        /// </summary>
        public static PartBuilder Create()
        {
            return new PartBuilder();
        }
        /// <summary>
        /// Gets a property name from an expression
        /// </summary>
        public PartBuilder AddPart<TEntity, TProp>(Expression<Func<TEntity, TProp>> expression)
        {
            PropertyInfo prop = (PropertyInfo)((MemberExpression)(expression.Body)).Member;
            this.Parts.Add(prop.Name);
            return this;
        }
    }
