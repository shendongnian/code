    public sealed class MvpContext : IMvpContext
    {
        private IContext _context;
        private IEnumerable<Parameter> _resolutionParameters;
        public MvpContext(IContext context, IEnumerable<Parameter> resolutionParameters)
        {
            _context = context;
            _resolutionParameters = resolutionParameters;
        }
        #region IContext
        // Pass through all calls to _context
        #endregion
        #region IMvpContext
        public T View<T>()
        {
            return _resolutionParameters.Named<T>(MvpViewParameter.ParameterName);
        }
        #endregion
    }
