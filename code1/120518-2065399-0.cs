	/// <overloads>
	/// Adds a CSS link to the page. Useful when you don't have access to the
	///  HeadContent ContentPlaceHolder. This method has 4 overloads.
	/// </overloads>
	/// <summary>
	/// Adds a CSS link.
	/// </summary>
	/// <param name="pathToCss">The path to CSS file.</param>
	public void AddCss(string pathToCss) {
		AddCss(pathToCss, string.Empty);
	}
	/// <summary>
	/// Adds a CSS link in a specific position.
	/// </summary>
	/// <param name="pathToCss">The path to CSS.</param>
	/// <param name="position">The postion.</param>
	public void AddCss(string pathToCss, int? position) {
		AddCss(pathToCss, string.Empty, position);
	}
	/// <summary>
	/// Adds a CSS link to the page with a specific media type.
	/// </summary>
	/// <param name="pathToCss">The path to CSS file.</param>
	/// <param name="media">The media type this stylesheet relates to.</param>
	public void AddCss(string pathToCss, string media) {
		AddHeaderLink(pathToCss, "text/css", "Stylesheet", media, null);
	}
	/// <summary>
	/// Adds a CSS link to the page with a specific media type in a specific
	/// position.
	/// </summary>
	/// <param name="pathToCss">The path to CSS.</param>
	/// <param name="media">The media.</param>
	/// <param name="position">The postion.</param>
	public void AddCss(string pathToCss, string media, int? position) {
		AddHeaderLink(pathToCss, "text/css", "Stylesheet", media, position);
	}
	/// <overloads>
	/// Adds a general header link. Useful when you don't have access to the
	/// HeadContent ContentPlaceHolder. This method has 3 overloads.
	/// </overloads>
	/// <summary>
	/// Adds a general header link.
	/// </summary>
	/// <param name="href">The path to the resource.</param>
	/// <param name="type">The type of the resource.</param>
	public void AddHeaderLink(string href, string type) {
		AddHeaderLink(href, type, string.Empty, string.Empty, null);
	}
	/// <summary>
	/// Adds a general header link.
	/// </summary>
	/// <param name="href">The path to the resource.</param>
	/// <param name="type">The type of the resource.</param>
	/// <param name="rel">The relation of the resource to the page.</param>
	public void AddHeaderLink(string href, string type, string rel) {
		AddHeaderLink(href, type, rel, string.Empty, null);
	}
	/// <summary>
	/// Adds a general header link.
	/// </summary>
	/// <param name="href">The path to the resource.</param>
	/// <param name="type">The type of the resource.</param>
	/// <param name="rel">The relation of the resource to the page.</param>
	/// <param name="media">The media target of the link.</param>
	public void AddHeaderLink(string href, string type, string rel, string media)
	{
		AddHeaderLink(href, type, rel, media, null);
	}
	/// <summary>
	/// Adds a general header link.
	/// </summary>
	/// <param name="href">The path to the resource.</param>
	/// <param name="type">The type of the resource.</param>
	/// <param name="rel">The relation of the resource to the page.</param>
	/// <param name="media">The media target of the link.</param>
	/// <param name="position">The postion in the control order - leave as null
	/// to append to the end.</param>
	public void AddHeaderLink(string href, string type, string rel, string media, 
	                          int? position) {
	  var link = new HtmlLink { Href = href };
	  if (0 != type.Length) {
	    link.Attributes.Add(HtmlTextWriterAttribute.Type.ToString().ToLower(), 
	                        type);
	  }
	  if (0 != rel.Length) {
	    link.Attributes.Add(HtmlTextWriterAttribute.Rel.ToString().ToLower(),
	                        rel);
	  }
	  if (0 != media.Length) {
	    link.Attributes.Add("media", media);
	  }
	  if (null == position || -1 == position) {
	    Page.Header.Controls.Add(link);
	  }
	  else
	  {
	    Page.Header.Controls.AddAt((int)position, link);
	  }
	}
