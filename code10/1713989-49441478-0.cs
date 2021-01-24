    Windows.UI.Core.Preview.SystemNavigationManagerPreview.GetForCurrentView().CloseRequested +=
                async (sender, args) =>
                {
                    args.Handled = true;
                    
    				var messageDialog = new MessageDialog("Do you want to exit?");
    
    				
    				messageDialog.Commands.Add(new UICommand(
    					"OK", 
    					new UICommandInvokedHandler(this.OKCommandInvokedHandler)));
    				messageDialog.Commands.Add(new UICommand(
    					"Cancel", 
    					new UICommandInvokedHandler(this.CancelCommandInvokedHandler)));
    
    				
    				messageDialog.DefaultCommandIndex = 0;
    				messageDialog.CancelCommandIndex = 1;
    				
    				await messageDialog.ShowAsync();
                };
			
    private void OKCommandInvokedHandler(IUICommand command)
    {
        
    }
    
    private void CancelCommandInvokedHandler(IUICommand command)
    {
    
    }
