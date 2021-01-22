    using System;
    using System.Runtime.InteropServices;
    
    namespace WhateverNamepaceYouAreUsing
    {
        class Magician
        {
            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
            const int HIDE = 0;
            const int SHOW = 5;
    
            public static void DisappearConsole()
            {
                ShowWindow(GetConsoleWindow(), HIDE);
            }
        }
    }
