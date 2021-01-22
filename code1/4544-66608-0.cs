        /// <summary>
        /// store a key value in registry. if it don't exist it will be created. 
        /// </summary>
        /// <param name="mainKey">the main key of key path</param>
        /// <param name="subKey">the path below the main key</param>
        /// <param name="keyName">the key name</param>
        /// <param name="value">the value to be stored</param>
        public static void SetRegistry(int mainKey, String subKey, String keyName, object value)
        {
            if (mainKey != CURRENT_USER && mainKey != LOCAL_MACHINE)
            {
                throw new ArgumentOutOfRangeException("mainKey", "\'mainKey\' argument can only be AppUtils.CURRENT_USER or AppUtils.LOCAL_MACHINE values");
            }
            if (subKey == null)
            {
                throw new ArgumentNullException("subKey", "\'subKey\' argument cannot be null");
            }
            if (keyName == null)
            {
                throw new ArgumentNullException("keyName", "\'keyName\' argument cannot be null");
            }
            const Boolean WRITABLE = true;
            RegistryKey key = null;
            if (mainKey == CURRENT_USER)
            {
                key = Registry.CurrentUser.OpenSubKey(subKey, WRITABLE);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(subKey);
                }
            }
            else if (mainKey == LOCAL_MACHINE)
            {
                key = Registry.LocalMachine.OpenSubKey(subKey, WRITABLE);
                if (key == null)
                {
                    key = Registry.LocalMachine.CreateSubKey(subKey);
                }
            }
            key.SetValue(keyName, value);
        }
        /// <summary>
        /// find a key value in registry. if it don't exist the default value will be returned.
        /// </summary>
        /// <param name="mainKey">the main key of key path</param>
        /// <param name="subKey">the path below the main key</param>
        /// <param name="keyName">the key name</param>
        /// <param name="defaultValue">the value to be stored</param>
        public static object GetRegistry(int mainKey, String subKey, String keyName, object defaultValue)
        {
            if (mainKey != CURRENT_USER && mainKey != LOCAL_MACHINE)
            {
                throw new ArgumentOutOfRangeException("mainKey", "\'mainKey\' argument can only be AppUtils.CURRENT_USER or AppUtils.LOCAL_MACHINE values");
            }
            if (subKey == null)
            {
                throw new ArgumentNullException("subKey", "\'subKey\' argument cannot be null");
            }
            if (keyName == null)
            {
                throw new ArgumentNullException("keyName", "\'keyName\' argument cannot be null");
            }
            RegistryKey key = Registry.CurrentUser.OpenSubKey(subKey);
            if (mainKey == CURRENT_USER)
            {
                key = Registry.CurrentUser.OpenSubKey(subKey);
            }
            else if (mainKey == LOCAL_MACHINE)
            {
                key = Registry.LocalMachine.OpenSubKey(subKey);
            }
            object result = defaultValue;
            if (key != null)
            {
                result = key.GetValue(keyName, defaultValue);
            }
            return result;
        }
