    public static void SendConsoleInputCR(bool UseConsoleSetupWasParentConsole)
    {
      if (UseConsoleSetupWasParentConsole && !ConsoleSetupWasParentConsole)
      {
        return;
      }
      long LongNegOne = -1;
      System.IntPtr NegOne = new System.IntPtr(LongNegOne);
      System.IntPtr StdIn = GetStdHandle(STD_INPUT_HANDLE);
      if (StdIn == NegOne)
      {
        return;
      }
      INPUT_RECORD[] ira = new INPUT_RECORD[2];
      ira[0].EventType = KEY_EVENT;
      ira[0].KeyEvent.bKeyDown = true;
      ira[0].KeyEvent.wRepeatCount = 1;
      ira[0].KeyEvent.wVirtualKeyCode = 0;
      ira[0].KeyEvent.wVirtualScanCode = 0;
      ira[0].KeyEvent.UnicodeChar = '\r';
      ira[0].KeyEvent.dwControlKeyState = 0;
      ira[1].EventType = KEY_EVENT;
      ira[1].KeyEvent.bKeyDown = false;
      ira[1].KeyEvent.wRepeatCount = 1;
      ira[1].KeyEvent.wVirtualKeyCode = 0;
      ira[1].KeyEvent.wVirtualScanCode = 0;
      ira[1].KeyEvent.UnicodeChar = '\r';
      ira[1].KeyEvent.dwControlKeyState = 0;
      uint recs = 2;
      uint zero = 0;
      WriteConsoleInput(StdIn, ira, recs, out zero);
    }
