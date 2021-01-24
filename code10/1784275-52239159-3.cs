        /// <summary>
        ///     Runs the action on UI thread.
        /// </summary>
        /// <param name="action">The action.</param>
        public static void RunOnUIThread(Action action)
        {
            try
            {
                if (Application.Current != null)
                    Application.Current.Dispatcher.Invoke(action);
            }
            catch (Exception ee)
            {
                _logger.Fatal("UI Thread Code Crashed. Action detail: " + action.Method, ee);
                //SystemManager.Instance.SendErrorEmailToCsaTeam("Kiosk Application Crashed", "UI Thread Code Crashed. Action detail: " + action.Method);
                throw;
            }
        }
