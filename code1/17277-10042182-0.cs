        /// <summary>
        /// Adds the specified query parameter to the URI builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The URI escaped value.</param>
        /// <returns>The final full query string.</returns>
        public static string AddQueryParam(this UriBuilder builder, string parameterName, string value)
        {
            if (parameterName == null)
                throw new ArgumentNullException("parameterName");
            if (parameterName.Length == 0)
                throw new ArgumentException("The parameter name is empty.");
            if (value == null)
                throw new ArgumentNullException("value");
            if (value.Length == 0)
                throw new ArgumentException("The value is empty.");
            if (builder.Query.Length == 0)
            {
                builder.Query = String.Concat(parameterName, "=", value);
            }
            else if
                (builder.Query.Contains(String.Concat("&", parameterName, "="))
                || builder.Query.Contains(String.Concat("?", parameterName, "=")))
            {
                throw new InvalidOperationException(String.Format("The parameter {0} already exists.", parameterName));
            }
            else
            {
                builder.Query = String.Concat(builder.Query.Substring(1), "&", parameterName, "=", value);
            }
            return builder.Query;
        }
