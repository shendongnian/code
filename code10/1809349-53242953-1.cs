        using System.Runtime.InteropServices;   // for GetKeyState
        ...
        private void keyDemo_KeyDown(object sender, KeyEventArgs e)
        {
            keyInfoLabel.Text =
                $"Alt: {(e.Alt ? "Yes" : "No")}\n" +
                $"Shift: {(e.Shift ? "Yes" : "No")}\n" +
                $"Ctrl: {(e.Control ? "Yes" : "No")}\n" +
                $"KeyCode: {e.KeyCode}\n" +
                $"KeyData: {e.KeyData}\n" +
                $"KeyValue: {e.KeyValue}\n" +
                $"CapsLock: {(CapsLockState ? "Yes" : "No")}\n" +
                $"Letter: {KeyToLetter(e.KeyData, CapsLockState)}";
        }
        // Import the DLL to use a Win32 API call.
        // See https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeystate
        // If using WPF, you could use Keyboard.IsKeyDown :
        //  https://docs.microsoft.com/en-us/dotnet/api/system.windows.input.keyboard.iskeydown?view=netframework-4.7.2
        [DllImport("user32.dll")]
        public static extern short GetKeyState(Keys nVirtKey);
        /// <summary>
        /// true if Caps Lock is on, otherwise false.
        /// </summary>
        public bool CapsLockState 
            => (GetKeyState(Keys.CapsLock) & 1) == 1;
        /// <summary/>
        /// <param name="key">A base key (no modifiers).</param>
        /// <returns>true if and only if the given key represents a letter.</returns>
        public static bool IsLetterKey(Keys key)
            => key >= Keys.A && key <= Keys.Z;
        /// <summary>
        /// Given a keystroke that produces a letter, this returns the letter.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="capsLockState"></param>
        /// <returns>the letter, or null if the given keystroke does not produce a letter.</returns>
        public static char? KeyToLetter(Keys key, bool capsLockState)
        {
            Keys baseKey = key & ~Keys.Modifiers;  // remove modifier keys
            if (IsLetterKey(baseKey) && !key.HasFlag(Keys.Control))    // if a letter
            {
                bool shiftPressed = key.HasFlag(Keys.Shift);   // check whether Shift was pressed
                bool capital = capsLockState ^ shiftPressed;   // if it should be capital
                if (capital)
                    return (char)baseKey;
                else
                    return Char.ToLower((char)baseKey);
            }
            else
            {
                return null;  // not a letter
            }
        }
