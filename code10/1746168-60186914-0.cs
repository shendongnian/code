            var application = new Microsoft.Office.Interop.Word.Application();
            application.Visible = false;
            application.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            object oFalse = false;
            var document = application.Documents.Open(ref fileName);
            document.Close();
            var format = document.AutoFormatOverride; --> This line throws the exception as the document instance is being accessed after closing it (i.e. may be disconnected already from the MS Word client)
            document.PrintOut(); --> This line would throw the exception if we skip the above line.
