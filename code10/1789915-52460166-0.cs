    public class ToggleDefineSymbol : Editor
    {
        [MenuItem("Tools/Set GOOGLE_MOBILE_GAMES")]
        public static void Set_GOOGLE_MOBILE_GAMES()
        {
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(
                BuildTargetGroup.Standalone);
            if (!symbols.Contains("GOOGLE_MOBILE_GAMES"))
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(
                    BuildTargetGroup.Standalone, symbols + ";GOOGLE_MOBILE_GAMES");
            }
        }
    
        [MenuItem("Tools/Unset GOOGLE_MOBILE_GAMES")]
        public static void Unset_GOOGLE_MOBILE_GAMES()
        {
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(
                BuildTargetGroup.Standalone);
            if (symbols.Contains("GOOGLE_MOBILE_GAMES"))
            {
                symbols = symbols.Replace(";GOOGLE_MOBILE_GAMES", "");
                PlayerSettings.SetScriptingDefineSymbolsForGroup(
                    BuildTargetGroup.Standalone, symbols);
            }
        }
    }
