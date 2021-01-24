    public class CustomRequired: RequiredAttribute
    {
     public override string FormatErrorMessage(string whatever)
     {
        return !String.IsNullOrEmpty(ErrorMessage)
            ? ErrorMessage
            : String.Format("{0} is required", whatever);
     }
    }
