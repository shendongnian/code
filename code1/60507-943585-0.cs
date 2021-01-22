    namespace Utility
    {
        public class UserPreferences
        {
            public UserPreferences(int userID)
            {
                // Load Preferences from text file, xml file or DB
                string loadedPreferences = "us|20|yes|no";
    
                HttpContext.Current.Session["userPreferences"] = loadedPreferences;
            }
    
            public void Savepreferences(string[] pref, int userID)
            { 
                // Save preferences for that user
            }
    
            public static string GetPreferences(PreferencesType type)
            {
                string[] pref = HttpContext.Current.Session["userPreferences"].ToString().Split('|');
    
                switch (type)
                {
                    case PreferencesType.Language: return pref[0];
                    case PreferencesType.ShowHowManyResults: return pref[1];
                    case PreferencesType.ShowNavigation: return pref[2];
                    case PreferencesType.GetEmailAlerts: return pref[3];
                }
            }
    
            public enum PreferencesType
            {
                Language, ShowHowManyResults, ShowNavigation, GetEmailAlerts
            }
        }
    }
