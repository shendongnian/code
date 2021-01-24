    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
    public sealed class LatestApiVersionAttribute : ApiVersionAttribute, IApiVersionProvider
    {
      public LatestApiVersionAttribute() : base( new ApiVersion( 2, 0 ) ) { }
    }
