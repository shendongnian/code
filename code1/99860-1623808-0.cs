        // Summary:
    //     Specifies the reason that a form was closed.
    public enum CloseReason
    {
        // Summary:
        //     The cause of the closure was not defined or could not be determined.
        None = 0,
        //
        // Summary:
        //     The operating system is closing all applications before shutting down.
        WindowsShutDown = 1,
        //
        // Summary:
        //     The parent form of this multiple document interface (MDI) form is closing.
        MdiFormClosing = 2,
        //
        // Summary:
        //     The user is closing the form through the user interface (UI), for example
        //     by clicking the Close button on the form window, selecting Close from the
        //     window's control menu, or pressing ALT+F4.
        UserClosing = 3,
        //
        // Summary:
        //     The Microsoft Windows Task Manager is closing the application.
        TaskManagerClosing = 4,
        //
        // Summary:
        //     The owner form is closing.
        FormOwnerClosing = 5,
        //
        // Summary:
        //     The System.Windows.Forms.Application.Exit() method of the System.Windows.Forms.Application
        //     class was invoked.
        ApplicationExitCall = 6,
    }
