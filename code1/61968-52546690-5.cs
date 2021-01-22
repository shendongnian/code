    /// <devdoc>
    ///     Retrieves the current state of the modifier keys. This will check the
    ///     current state of the shift, control, and alt keys.
    /// </devdoc>
    public static Keys ModifierKeys {
        get {
            Keys modifiers = 0;
            // SECURITYNOTE : only let state of Shift-Control-Alt out...
            //
            if (UnsafeNativeMethods.GetKeyState((int)Keys.ShiftKey) < 0) modifiers |= Keys.Shift;
            if (UnsafeNativeMethods.GetKeyState((int)Keys.ControlKey) < 0) modifiers |= Keys.Control;
            if (UnsafeNativeMethods.GetKeyState((int)Keys.Menu) < 0) modifiers |= Keys.Alt;
            return modifiers;
        }
    }
