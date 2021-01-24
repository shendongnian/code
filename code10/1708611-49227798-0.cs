    public void OnPageSelected(int position)
    {
        if (position == 0)
        {
            // because the keyboard has been forced to hide in graphic fragment,
            // when you back to edittext fragment, you need force to show it.
            EditTextFragment.showKeyboard();
        }
        else if (position == 1)
        {
            //In your graphic fragment, hide the keyboard.
            ((InputMethodManager)GetSystemService(Context.InputMethodService)).
                    HideSoftInputFromInputMethod(CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }
    }
