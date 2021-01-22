    /// <summary>
    /// Represents a <see cref="Provider{TArg,TServiceType}"/> which holds 
    /// the container context and resolves the service on the <see cref="Create"/>-call
    /// </summary>
    internal class GenericFactory{
        private readonly IContainer container; 
    
        public ClosureActivator(IContainer container)
        {
            this.container= container;
        } 
    
        /// <summary>
        ///  Represents <see cref="Provider{TServiceType}.Invoke"/>
        /// </summary>
        public TService Create()
        {
            return container.Resolve<TService>();
        }
        /// <summary>
        /// Represents <see cref="Provider{TArg,TServiceType}.Invoke"/>
        /// </summary>
        public TService Create(TArg arg)
        {        
            return container.Resolve<TService>(new[] {new TypedParameter(typeof (TArg),arg)});
        }
    }
