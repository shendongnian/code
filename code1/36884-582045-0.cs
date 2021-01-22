    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public HttpResponse Response
    {
        get
        {
            if (this._response == null)
            {
                throw new HttpException(SR.GetString("Response_not_available"));
            }
            return this._response;
        }
    }
