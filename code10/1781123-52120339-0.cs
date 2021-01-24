    /// <summary>
    /// Creates an <see cref="BadRequestResult"/> that produces a <see cref="StatusCodes.Status400BadRequest"/> response.
    /// </summary>
    /// <returns>The created <see cref="BadRequestResult"/> for the response.</returns>
    [NonAction]
    public virtual BadRequestResult BadRequest()
        => new BadRequestResult();
    /// <summary>
    /// Creates an <see cref="BadRequestObjectResult"/> that produces a <see cref="StatusCodes.Status400BadRequest"/> response.
    /// </summary>
    /// <param name="error">An error object to be returned to the client.</param>
    /// <returns>The created <see cref="BadRequestObjectResult"/> for the response.</returns>
    [NonAction]
    public virtual BadRequestObjectResult BadRequest(object error)
        => new BadRequestObjectResult(error);
    /// <summary>
    /// Creates an <see cref="BadRequestObjectResult"/> that produces a <see cref="StatusCodes.Status400BadRequest"/> response.
    /// </summary>
    /// <param name="modelState">The <see cref="ModelStateDictionary" /> containing errors to be returned to the client.</param>
    /// <returns>The created <see cref="BadRequestObjectResult"/> for the response.</returns>
    [NonAction]
    public virtual BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
    {
        if (modelState == null)
        {
            throw new ArgumentNullException(nameof(modelState));
        }
        return new BadRequestObjectResult(modelState);
    }
