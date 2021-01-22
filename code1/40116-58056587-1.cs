    public class DatabasePreference {
        public DatabasePreference([CallerMemberName] string preferenceName = "") {
            PreferenceName = preferenceName;
        }
        public string PreferenceName;
    }
    
    //Declare names here
    public static DatabasePreference ScannerDefaultFlashLight = new DatabasePreference();
    public static DatabasePreference ScannerQrCodes = new DatabasePreference();
    public static DatabasePreference Scanner1dCodes = new DatabasePreference();
