        /// <summary>
        /// Sets model value.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="me">Me.</param>
        /// <param name="lambdaExpression">The lambda expression.</param>
        ///<param name="value">New Value</param>
        public static void SetModelValue<TViewModel, TProperty>(
            this ModelStateDictionary me,
            Expression<Func<TViewModel, TProperty>> lambdaExpression,
            object value)
        {
            string key = WebControlsExtensions.GetIdFor<TViewModel, TProperty>(lambdaExpression, ".");
            if (!string.IsNullOrWhiteSpace(key))
            {
                me.SetModelValue(key, new ValueProviderResult(value, String.Empty, System.Globalization.CultureInfo.InvariantCulture));
            }
        }
