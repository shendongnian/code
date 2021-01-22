    public override void WriteDocType(string name, string pubid, string sysid, string subset)
    {
        if ((pubid == null) && (sysid == null) && (subset == null))
        {
            this.wrappedWriter.WriteRaw("<!DOCTYPE HTML>");
        }
        else
        {
            this.wrappedWriter.WriteDocType(name, pubid, sysid, subset);
        }
    }
