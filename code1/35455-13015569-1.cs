    public static class WebControlsExtensions
    {
        /// <summary>
        /// Devuelve el Id correspondiente a la expresión lambda pasada por parámetro reemplazando los caracteres inválidos por la cadena pasada por parámetro
        /// </summary>
        /// <typeparam name="TViewModel">El tipo del modelo</typeparam>
        /// <typeparam name="TProperty">El tipo de la propiedad</typeparam>
        /// <param name="expression">Expresión lambda</param>
        /// <param name="invalidCharReplacement">Cadena de texto que reemplaza a los carácteres inválido</param>
        /// <remarks>
        /// Valid characters consist of letters, numbers, and the hyphen ("-"), underscore ("_"), and colon (":") characters. 
        /// All other characters are considered invalid. Each invalid character in originalId is replaced with the character specified in the HtmlHelper.IdAttributeDotReplacement property.
        /// </remarks>
        /// <returns> Devuelve el Id correspondiente a la expresión lambda</returns>
        public static string GetIdFor<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, string invalidCharReplacement)
        {
            return TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression), invalidCharReplacement);
        }
    }
