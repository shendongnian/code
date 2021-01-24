    /// <summary>
    /// Gets or sets <see cref="ViewDataDictionary"/> used by <see cref="ViewResult"/> and <see cref="ViewBag"/>.
    /// </summary>
    /// <remarks>
    /// By default, this property is intiailized when <see cref="Controllers.IControllerActivator"/> activates
    /// controllers.
    /// <para>
    /// This property can be accessed after the controller has been activated, for example, in a controller action
    /// or by overriding <see cref="OnActionExecuting(ActionExecutingContext)"/>.
    /// </para>
    /// <para>
    /// This property can be also accessed from within a unit test where it is initialized with
    /// <see cref="EmptyModelMetadataProvider"/>.
    /// </para>
    /// </remarks>
    [ViewDataDictionary]
    public ViewDataDictionary ViewData
