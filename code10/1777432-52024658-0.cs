        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ...
            // get excel window
            var excelWnd = Microsoft.Win32.Interop.FindWindow("XLMAIN", null);
            // move excel somewhere outside the screen (of course you should compute it, not hardcode it)
            Microsoft.Win32.Interop.MoveWindow(excelWnd, -10000, -10000, 800, 600, true);
            // show it so it's initialized properly
            ExcelApplication.Visible = true;
            GenerateTestData(ExcelApplication);
            // now call SetParent
            Microsoft.Win32.Interop.SetParent(excelWnd, hwnd.Handle);
            // move it to parent
            Microsoft.Win32.Interop.MoveWindow(excelWnd, 10, 10, 800, 600, true);
        }
