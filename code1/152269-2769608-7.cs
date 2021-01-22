    /// <summary>
    ///   Gets the entity associated to the given Uri, role, and
    ///   Type.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The only Type that is supported is the System.IO.Stream.
    ///   </para>
    ///   <para>
    ///     The only Uri's supported are those for W3C XHTML 1.0.
    ///   </para>
    /// </remarks>
    public override object GetEntity(Uri absoluteUri, string role, Type t)
    {
        // only handle streams
        if (t != typeof(System.IO.Stream))
            throw new ArgumentException();
        if (absoluteUri == null)
            throw new ArgumentException();
        var uri = absoluteUri.AbsoluteUri;
        foreach (var key in knownDtds.Keys)
        {
            if (uri.StartsWith(knownDtds[key]))
            {
                // Return the stream containing the requested DTD. 
                // This can be a FileStream, HttpResponseStream, MemoryStream, 
                // or whatever other stream you like.  I used a Resource stream
                // myself.  If you retrieve the DTDs via HTTP, you could use your
                // own IWebProxy here.  
                var resourceName = GetResourceName(key, uri.Substring(knownDtds[key].Length));
                return GetStreamForNamedResource(resourceName);
            }
        }
        throw new ArgumentException();
    }
