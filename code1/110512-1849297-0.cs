        internal object GetModelStateValue(string key, Type destinationType) {
            ModelState modelState;
            if (ViewData.ModelState.TryGetValue(key, out modelState)) {
                if (modelState.Value != null) {
                    return modelState.Value.ConvertTo(destinationType, null /* culture */);
                }
            }
            return null;
        }
