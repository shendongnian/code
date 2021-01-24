    private void InitializeGeckoEngine()
        {
            
            try
            {
                if (!Directory.Exists(Paths.XulRunner))
                {
                    MessageBox.Show($"Firefox folder not found at {Paths.XulRunner}!");
                }
                Xpcom.EnableProfileMonitoring = false;
                Xpcom.Initialize(Paths.XulRunner);
                                  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Firefox engine not detected or was not loaded correctly. Loading path: {Paths.XulRunner}. Exception details:\n" + ex + ex.InnerException, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
        }
