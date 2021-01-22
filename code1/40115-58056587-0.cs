    public class DatabasePreference {
        public DatabasePreference([CallerMemberName] string preferenceName = "") {
            PreferenceName = preferenceName;
        }
        public string PreferenceName;
    }
    
    //Declare names here
    public DatabasePreference ScannerDefaultFlashLight = new DatabasePreference();
    public DatabasePreference ScannerQrCodes = new DatabasePreference();
    public DatabasePreference Scanner1dCodes = new DatabasePreference();
