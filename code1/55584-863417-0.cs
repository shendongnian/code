    void TraceLine(string msg, bool OmitDate)
    {
        if (!OmitDate)
            msg = DateTime.Now + " " + msg;
        Trace.WriteLine(msg);
    }
    void TraceLine(string msg) {TraceLine(msg, false);}
