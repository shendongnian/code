    private void SearchButton_Click(object sender, EventArgs e)
    {
        dynamic ax = webBrowser1.ActiveXInstance;
        // IHtmlDocument2 also implements IOleCommandTarget
        var qi = (IOleCommandTarget)ax.Document;
        // MSHTML commands group
        var CGID_MSHTML = new Guid("de4ba900-59ca-11cf-9592-444553540000");
        const int IDM_FIND = 67;
        qi.Exec(CGID_MSHTML, IDM_FIND, 0, null, null);
    }
    [Guid("b722bccb-4e68-101b-a2bc-00aa00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleCommandTarget
    {
        void NotDefinedHere(); // don't remove this
        [PreserveSig]
        int Exec([MarshalAs(UnmanagedType.LPStruct)] Guid pguidCmdGroup, int nCmdID, int nCmdexecopt, object pvaIn, [In, Out] object pvaOut);
    }
