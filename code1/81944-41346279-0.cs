        void SetAttribute(object chickenDuckOrWhatever, string attributeName, string value)
        {
            var typeOfObject = chickenDuckOrWhatever.GetType();
            var property = typeOfObject.GetProperty(attributeName);
            if (property != null)
            {
                property.SetValue(chickenDuckOrWhatever, value);
                return;
            }
            //No property with this name was found, fall back to field
            var field = typeOfObject.GetField(attributeName);
            if (field == null) throw new Exception("No property or field was found on type '" + typeOfObject.FullName + "' by the name of '" + attributeName + "'.");
            field.SetValue(chickenDuckOrWhatever, value);
        }
