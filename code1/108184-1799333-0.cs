    public interface IValidatable {
        public bool IsValid();
    }
    public class TextBoxRequired : Textbox, IValidatable {
        public bool IsValid() {
            return !string.IsNullOrEmpty(this.Text);
        } 
    }
    //
    public static class ValidationHelper {
        public static bool IsFormValid(Form form) {
            //loop through all controls in the form
            //find IValidatable and call IsValid
        }
    }
