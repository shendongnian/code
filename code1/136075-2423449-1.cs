      /// <summary>
      /// Enables access to objects across application domain boundaries.
      /// Contrary to MarshalByRefObject, the lifetime is managed by the client.
      /// </summary>
      public abstract class CrossAppDomainObject : MarshalByRefObject
      {
        /// <summary>
        /// Count of remote references to this object.
        /// </summary>
        [NonSerialized]
        private int refCount;
    
        /// <summary>
        /// Creates an object that contains all the relevant information required to
        /// generate a proxy used to communicate with a remote object.
        /// </summary>
        /// <param name="requestedType">The System.Type of the object that the new System.Runtime.Remoting.ObjRef will reference.</param>
        /// <returns>Information required to generate a proxy.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override ObjRef CreateObjRef(Type requestedType)
        {
          CrossAppDomainObjRef objRef = new CrossAppDomainObjRef(this, requestedType);
          return objRef;
        }
    
        /// <summary>
        /// Disables LifeTime service : object has an infinite life time until it's Disconnected.
        /// </summary>
        /// <returns>null.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override object InitializeLifetimeService()
        {
          return null;
        }
    
        /// <summary>
        /// Connect a proxy to the object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AppDomainConnect()
        {
          int value = Interlocked.Increment(ref refCount);
          Debug.Assert(value > 0);
        }
    
        /// <summary>
        /// Disconnects a proxy from the object.
        /// When all proxy are disconnected, the object is disconnected from RemotingServices.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AppDomainDisconnect()
        {
          Debug.Assert(refCount > 0);
          if (Interlocked.Decrement(ref refCount) == 0)
            RemotingServices.Disconnect(this);
        }
      }
