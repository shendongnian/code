            /// <summary>
        /// Executes the action if not the field is deprecated 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <typeparam name="TForm"></typeparam>
        /// <param name="form"></param>
        /// <param name="memberExpression"></param>
        /// <param name="actionToPerform"></param>
        /// <returns>True if the action was performed</returns>
        public static bool ExecuteActionIfNotDeprecated<TForm, TProperty>(this TForm form, Expression<Func<TForm, TProperty>> memberExpression, Action actionToPerform)
        {
            var memberExpressionConverted = memberExpression.Body as MemberExpression;
            if (memberExpressionConverted == null)
                return false; 
            string memberName = memberExpressionConverted.Member.Name;
            PropertyInfo matchingProperty = typeof(TForm).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.Name == memberName);
            if (matchingProperty == null)
                return false; //should not occur
            var fieldMeta = matchingProperty.GetCustomAttribute(typeof(FieldMetadataAttribute), true) as FieldMetadataAttribute;
            if (fieldMeta == null)
            {
                actionToPerform();
                return true;
            }
            var formConverted = form as FormDataContract;
            if (formConverted == null)
                return false;
            if (fieldMeta.DeprecatedFromMajorVersion > 0 && formConverted.MajorVersion > fieldMeta.DeprecatedFromMajorVersion)
            {
                //major version of formConverted is deprecated for this field - do not execute action
                return false;
            }
            if (fieldMeta.DeprecatedFromMinorVersion > 0 && fieldMeta.DeprecatedFromMajorVersion > 0
                                                         && formConverted.MinorVersion >= fieldMeta.DeprecatedFromMinorVersion
                                                         && formConverted.MajorVersion >= fieldMeta.DeprecatedFromMajorVersion)
                return false; //the field is expired - do not invoke action 
            actionToPerform();
            return true;
        }
