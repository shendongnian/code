    /// <summary>
    /// Factory for creating application service proxies used on the workstation
    /// </summary>
    /// <typeparam name="TInterface">Interface for the service contract</typeparam>
    public class ServiceFactory<TInterface> where TInterface : class
    {
        private readonly List<IEndpointBehavior> m_Behaviors = new List<IEndpointBehavior>();
        /// <summary>
        /// Add a behavior that is added to the proxy endpoint when the channel is created.
        /// </summary>
        /// <param name="behavior">An <see cref="IEndpointBehavior"/> that should be added</param>.
        public void AddBehavior(IEndpointBehavior behavior)
        {
            m_Behaviors.Add(behavior);
        }
        /// <summary>
        /// Creates a channel of type <see cref="CommunicationObjectInterceptor{TInterface}"/> given the endpoint address which 
        /// will recreate its "inner channel" if it becomes in a faulted state.
        /// </summary>
        /// <param name="url">The endpoint address for the given channel to connect to</param>.
        public TInterface CreateChannel(string url)
        {
            // create the channel using channelfactory adding the behaviors in m_Behaviors
        }
    }
