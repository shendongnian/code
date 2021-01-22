        /// <summary>
        /// Determines whether the specified app domain is a web app.
        /// </summary>
        /// <param name="appDomain">The app domain.</param>
        /// <returns>
        /// 	<c>true</c> if the specified app domain is a web app; otherwise, 
        /// <c>false</c>.
        /// </returns>
        public static bool IsWebApp(this AppDomain appDomain)
        {
            var configFile = (string)appDomain.GetData("APP_CONFIG_FILE");
            if (string.IsNullOrEmpty(configFile)) return false;
            return (
              Path.GetFileNameWithoutExtension(configFile) ?? string.Empty
              ).Equals(
                "WEB", 
                StringComparison.OrdinalIgnoreCase);
        }
	}
