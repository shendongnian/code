    public static class FormCollectionExtensions
        {
            public static string GetSubmitButtonName(this FormCollection formCollection)
            {
                return GetSubmitButtonName(formCollection, true);
            }
    
            public static string GetSubmitButtonName(this FormCollection formCollection, bool throwOnError)
            {
                var button = formCollection.Keys.OfType<string>().Where(x => x.EndsWith(".x")).SingleOrDefault();
    
                // we got something like AddToCart.x
                if (button != null)
                {
                    return button.Substring(0, button.Length - 2);
                }
    
                if (throwOnError)
                {
                    throw new ApplicationException("No image button found");
                }
                else
                {
                    return null;
                }
            }
        }
