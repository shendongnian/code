    public object Clone()
    {
        Version version = new Version();
        version._Major = this._Major;
        version._Minor = this._Minor;
        version._Build = this._Build;
        version._Revision = this._Revision;
        return version;
    }
 
