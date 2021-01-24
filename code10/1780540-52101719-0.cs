    /// <summary>
    /// Creates a <see cref="JsonResult"/> object that serializes the specified <paramref name="data"/> object
    /// to JSON.
    /// </summary>
    /// <param name="data">The object to serialize.</param>
    /// <returns>The created <see cref="JsonResult"/> that serializes the specified <paramref name="data"/>
    /// to JSON format for the response.</returns>
    [NonAction]
    public virtual JsonResult Json(object data)
    {
        return new JsonResult(data);
    }
    /// <summary>
    /// Creates a <see cref="JsonResult"/> object that serializes the specified <paramref name="data"/> object
    /// to JSON.
    /// </summary>
    /// <param name="data">The object to serialize.</param>
    /// <param name="serializerSettings">The <see cref="JsonSerializerSettings"/> to be used by
    /// the formatter.</param>
    /// <returns>The created <see cref="JsonResult"/> that serializes the specified <paramref name="data"/>
    /// as JSON format for the response.</returns>
    /// <remarks>Callers should cache an instance of <see cref="JsonSerializerSettings"/> to avoid
    /// recreating cached data with each call.</remarks>
    [NonAction]
    public virtual JsonResult Json(object data, JsonSerializerSettings serializerSettings)
    {
        if (serializerSettings == null)
        {
            throw new ArgumentNullException(nameof(serializerSettings));
        }
        return new JsonResult(data, serializerSettings);
    }
