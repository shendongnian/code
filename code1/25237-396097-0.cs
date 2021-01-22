    /// <summary>
    /// The MAPISendMail function sends a message.
    ///
    /// This function differs from the MAPISendDocuments function in that it allows greater
    /// flexibility in message generation.
    /// </summary>
    [DllImport("MAPI32.DLL", CharSet=CharSet.Ansi)]
    public static extern uint MAPISendMail(IntPtr lhSession, IntPtr ulUIParam,
    MapiMessage lpMessage, uint flFlags, uint ulReserved);
