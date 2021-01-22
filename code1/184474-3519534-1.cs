    public bool Read()
    {
      this.OnTraceEnterEvent("Read", null);
      if (this._disposed)
      {
        throw new NullReferenceException();
      }
      if (this.IsClosed)
      {
        throw new AseException(DriverMsgNumber.ERR_RESULTSET_DEAD, null);
      }
      bool state = false;
      if (!this._bNoResultSet)
      {
        state = this.Peform_Next();
        state = this.CheckSingleRow(state);
      }
      this.OnTraceExitEvent("Read", state);
      return state;
    }
