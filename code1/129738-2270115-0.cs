    public class ConventionModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            HumanizePropertyNamesAsDisplayName(metadata);
            if (metadata.DisplayName.ToUpper() == "ID")
                metadata.DisplayName = "Id Number";
            return metadata;
        }
        private void HumanizePropertyNamesAsDisplayName(ModelMetadata metadata)
        {
            metadata.DisplayName = HumanizeCamel((metadata.DisplayName ?? metadata.PropertyName));
        }
        public static string HumanizeCamel(string camelCasedString)
        {
            if (camelCasedString == null)
                return "";
            StringBuilder sb = new StringBuilder();
            char last = char.MinValue;
            foreach (char c in camelCasedString)
            {
                if (char.IsLower(last) && char.IsUpper(c))
                {
                    sb.Append(' ');
                }
                sb.Append(c);
                last = c;
            }
            return sb.ToString();
        }
    }
