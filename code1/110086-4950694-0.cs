	static public class ConfigHack {
		static public void OverrideAppConfig(string path) {
			((AppDomainSetup)
				typeof(AppDomain)
					.GetField("_FusionStore", BindingFlags.NonPublic | BindingFlags.Instance)
					.GetValue(AppDomain.CurrentDomain))
			.ConfigurationFile = path;
		}
		static public void ResetConfigManager() {
			typeof(ConfigurationManager)
				.GetField("s_initState", BindingFlags.Static | BindingFlags.NonPublic)
				.SetValue(null, 0);
		}
	}
