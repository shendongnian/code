    public static string SelectedText
    {
        get
        {
            AutomationElement focusedElement = AutomationElement.FocusedElement;
            object currentPattern = null;
            if (focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out currentPattern))
            {
                TextPattern textPattern = (TextPattern)currentPattern;
                TextPatternRange[] textPatternRanges = textPattern.GetSelection();
                if (textPatternRanges.Length > 0)
                {
                    string textSelection = textPatternRanges[0].GetText(-1);
                    return textSelection;
                }
            }
            return string.Empty;
        }
        set
        {
            AutomationElement focusedElement = AutomationElement.FocusedElement;
            IntPtr windowHandle = new IntPtr(focusedElement.Current.NativeWindowHandle);
            NativeMethods.SendMessage(windowHandle, NativeMethods.EM_REPLACESEL, true, value);
        }
    }
