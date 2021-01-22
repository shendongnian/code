        //
        // Summary:
        //     Starts a process resource by specifying the name of a document or application
        //     file and associates the resource with a new System.Diagnostics.Process component.
        //
        // Parameters:
        //   fileName:
        //     The name of a document or application file to run in the process.
        //
        // Returns:
        //     A new System.Diagnostics.Process component that is associated with the process
        //     resource, or null, if no process resource is started (for example, if an
        //     existing process is reused).
        //
        // Exceptions:
        //   System.ComponentModel.Win32Exception:
        //     There was an error in opening the associated file.
        //
        //   System.ObjectDisposedException:
        //     The process object has already been disposed.
        //
        //   System.IO.FileNotFoundException:
        //     The PATH environment variable has a string containing quotes.
