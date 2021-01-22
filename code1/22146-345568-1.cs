    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public bool Bar {
        get {
            try {
                return ((bool)(this[this.tableradio.BarColumn]));
            }
            catch (global::System.InvalidCastException e) {
                throw new global::System.Data.StrongTypingException("The value for column \'Bar\' in table \'radio\' is DBNull.", e);
            }
        }
        set {
            this[this.tableradio.BarColumn] = value;
            this[this.tableradio.FooColumn] = !value;
        }
    }
