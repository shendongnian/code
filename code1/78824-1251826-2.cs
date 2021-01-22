        //
        // Summary:
        //     Shows the form with the specified owner to the user.
        //
        // Parameters:
        //   owner:
        //     Any object that implements System.Windows.Forms.IWin32Window and represents
        //     the top-level window that will own this form.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The form specified in the owner parameter is the same as the form being shown.
        public void Show(IWin32Window owner);
