    public class DatabasePreference {
        public DatabasePreference([CallerMemberName] string preferenceName = "") {
            PreferenceName = preferenceName;
        }
        public string PreferenceName;
    }
