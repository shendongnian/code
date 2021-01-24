    RelayCommand<object> m_PrintAllChartsCommand;
    		public ICommand PrintAllChartsCommand
    		{
    			get
    			{
    
    				return m_PrintAllChartsCommand ?? (m_PrintAllChartsCommand = new RelayCommand<object>(
    					OnPrintAllChartsInCurrentView, IsPrintAndExportEnabled));
    					
    			}
    		}
    private void OnPrintAllChartsInCurrentView(object arg)
     {
    
     }
    
     private bool IsPrintAndExportEnabled(object arg)
     {
     }
