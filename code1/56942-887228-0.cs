    /// <summary>
    ///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
    ///      Receives notification that the host application is being unloaded.
    /// </summary>
    /// <param term='custom'>
    ///      Array of parameters that are host application specific.
    /// </param>
    /// <seealso class='IDTExtensibility2' />
    public virtual void OnBeginShutdown(ref System.Array custom)
    {
         // do clean-up when PowerPoint exits.
    }
