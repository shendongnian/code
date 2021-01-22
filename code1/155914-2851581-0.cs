    // file1.cs  (code gen'd)
    public partial class Validation {
        partial void OnValidate(ChangeAction action);
        private void SomeMethod() {
            OnValidate( ChangeAction.Whatever );
        }
    }
    // file2.cs (Validation class body)
    public partial class Validation {
        //partial void OnValidate(ChangeAction action) { ... }
    }
    public class Dinner : Validation {
        public void SomeOtherMethod() {
           OnValidate(null); // won't compile ... OnValidate doesn't exist
        }
    }
