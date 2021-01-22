        private static bool? isDesignMode;
        private static bool IsDesignMode()
        {
            if (isDesignMode == null)
                isDesignMode = (Process.GetCurrentProcess().ProcessName.ToLower().Contains("devenv"));
            return isDesignMode.Value;
        }
