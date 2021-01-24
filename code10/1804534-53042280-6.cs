    public class CustomRequired: RequiredAttribute
    {
        public override string FormatErrorMessage(string whatever)
        {
            return !String.IsNullOrEmpty(ErrorMessage)
            ? ErrorMessage
            : String.Format("Le champ {0} est requis.", whatever);
        }
    }
