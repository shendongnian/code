    public class CustomRequired: RequiredAttribute
    {
        public override string FormatErrorMessage(string whatever)
        {
            return !String.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Le champ {whatever} est requis.";
        }
    }
