    public static class FormCollectionExtensions
    {
        public static string GetSubmitButtonName(this FormCollection formCollection)
        {
            return GetSubmitButtonName(formCollection, true);
        }
        public static string GetSubmitButtonName(this FormCollection formCollection, bool throwOnError)
        {
            var imageButton = formCollection.Keys.OfType<string>().Where(x => x.EndsWith(".x")).SingleOrDefault();
            var textButton = formCollection.Keys.OfType<string>().Where(x => x.StartsWith("Submit_")).SingleOrDefault();
            if (textButton != null)
            {
                return textButton.Substring("Submit_".Length);
            }
            // we got something like AddToCart.x
            if (imageButton != null)
            {
                return imageButton.Substring(0, imageButton.Length - 2);
            }
            if (throwOnError)
            {
                throw new ApplicationException("No button found");
            }
            else
            {
                return null;
            }
        }
    }
