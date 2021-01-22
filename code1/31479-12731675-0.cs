    using Microsoft.Win32;
    using System.Collections;
    internal static class Extensions
    {
        /// <summary>
        /// Gets a dictionary containing known file extensions and description from HKEY_CLASSES_ROOT.
        /// </summary>
        /// <returns>dictionary containing extensions and description.</returns>
        public static Dictionary<string, string> GetAllRegisteredFileExtensions()
        {
            //get into the HKEY_CLASSES_ROOT
            RegistryKey root = Registry.ClassesRoot;
            //generic list to hold all the subkey names
            Dictionary<string, string> subKeys = new Dictionary<string, string>();
            //IEnumerator for enumerating through the subkeys
            IEnumerator enums = root.GetSubKeyNames().GetEnumerator();
            //make sure we still have values
            while (enums.MoveNext())
            {
                //all registered extensions start with a period (.) so
                //we need to check for that
                if (enums.Current.ToString().StartsWith("."))
                    //valid extension so add it and the default description if it exists
                    subKeys.Add(enums.Current.ToString(), Registry.GetValue(root.Name + "\\" + enums.Current.ToString(), "", "").ToString());
            }
            return subKeys;
        }   
    }
