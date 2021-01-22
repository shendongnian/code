    public interface IValidatable {
      bool IsValid { get; set; }
      void ShowValidationFailureMessage(string message);
    }
    public interface ISubmitable {
      event EventHandler Submit;
      void ShowSubmitFailureMessage(string message);
      void ShowSubmitSuccessMessage(string message);
    }
    public interface ICancelable {
      event EventHandler Cancel;
    }
