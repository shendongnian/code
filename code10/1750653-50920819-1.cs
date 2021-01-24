    [TearDown]
        public void Cleanup()
        {
            typeof(FusionLicenseProvider).GetField("isShown ", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static).SetValue(obj, false);
            typeof(FusionLicenseProvider).GetField("registery", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static).SetValue(obj, New List<string>());
        }
