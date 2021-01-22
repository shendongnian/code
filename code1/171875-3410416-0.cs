    public virtual void PopulateCssTag(string tags)
    {
        // tags is a pre-compsed string containing all the tags I need.
        this.Wrapper = this.Wrapper.Replace("</head>", tags + "</head>");
    }
