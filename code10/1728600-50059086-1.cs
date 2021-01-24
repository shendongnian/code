    public Uri ImageUri
	{
	    get
	    {
            return string.IsNullOrWhiteSpace(this.ImageName) ? null : new Uri(string.Format("urlOfPallication/Folder/{0}", this.ImageName));
	    }
	}
