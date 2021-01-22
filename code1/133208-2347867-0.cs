    public class CustomRequiredAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return YourCustomResourceManager.GetResource(name);
        }
    }
