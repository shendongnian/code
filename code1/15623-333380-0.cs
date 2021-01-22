        /// <summary>
        /// Get a list of available Application Pools
        /// </summary>
        /// <returns></returns>
        public static List<string> HentAppPools() {
            List<string> list = new List<string>();
            DirectoryEntry W3SVC = new DirectoryEntry("IIS://LocalHost/w3svc", "", "");
            foreach (DirectoryEntry Site in W3SVC.Children) {
                if (Site.Name == "AppPools") {
                    foreach (DirectoryEntry child in Site.Children) {
                        list.Add(child.Name);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Recycle an application pool
        /// </summary>
        /// <param name="IIsApplicationPool"></param>
        public static void RecycleAppPool(string IIsApplicationPool) {
            ManagementScope scope = new ManagementScope(@"\\localhost\root\MicrosoftIISv2");
            scope.Connect();
            ManagementObject appPool = new ManagementObject(scope, new ManagementPath("IIsApplicationPool.Name='W3SVC/AppPools/" + IIsApplicationPool + "'"), null);
            appPool.InvokeMethod("Recycle", null, null);
        }
