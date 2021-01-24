    InputMethodManager inputManager = (InputMethodManager)MainActivity.TheInstance.GetSystemService(Context.InputMethodService);
                var currentFocus = MainActivity.TheInstance.CurrentFocus;
                if (currentFocus != null)
                {
                    inputManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
                }
    
                MainActivity.TheInstance.Window.SetSoftInputMode(SoftInput.StateHidden);
