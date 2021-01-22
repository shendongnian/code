    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing)
            {
                this._isOpen = false;
                this._writable = false;
                this._expandable = false;
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }
