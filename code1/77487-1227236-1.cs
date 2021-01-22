     set
        {
            this._handler = value;
            this.RequiresSessionState = false;
            this.ReadOnlySessionState = false;
            this.InAspCompatMode = false;
            if (this._handler != null)
            {
                if (this._handler is IRequiresSessionState)
                {
                    this.RequiresSessionState = true;
                }
                if (this._handler is IReadOnlySessionState)
                {
                    this.ReadOnlySessionState = true;
                }
                Page page = this._handler as Page;
                if ((page != null) && page.IsInAspCompatMode)
                {
                    this.InAspCompatMode = true;
                }
            }
        }
