      /// <summary>
      /// Stores all relevant information required to generate a proxy in order to communicate with a remote object.
      /// Disconnects the remote object (server) when finalized on local host (client).
      /// </summary>
      [Serializable]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public sealed class CrossAppDomainObjRef : ObjRef
      {
        /// <summary>
        /// Initializes a new instance of the CrossAppDomainObjRef class to
        /// reference a specified CrossAppDomainObject of a specified System.Type.
        /// </summary>
        /// <param name="instance">The object that the new System.Runtime.Remoting.ObjRef instance will reference.</param>
        /// <param name="requestedType"></param>
        public CrossAppDomainObjRef(CrossAppDomainObject instance, Type requestedType)
          : base(instance, requestedType)
        {
          //Proxy created locally (not remoted), the finalizer is meaningless.
          GC.SuppressFinalize(this);
        }
    
        /// <summary>
        /// Initializes a new instance of the System.Runtime.Remoting.ObjRef class from
        /// serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination of the exception.</param>
        private CrossAppDomainObjRef(SerializationInfo info, StreamingContext context)
          : base(info, context)
        {
          Debug.Assert(context.State == StreamingContextStates.CrossAppDomain);
          Debug.Assert(IsFromThisProcess());
          Debug.Assert(IsFromThisAppDomain() == false);
          //Increment ref counter
          CrossAppDomainObject remoteObject = (CrossAppDomainObject)GetRealObject(new StreamingContext(StreamingContextStates.CrossAppDomain));
          remoteObject.AppDomainConnect();
        }
    
        /// <summary>
        /// Disconnects the remote object.
        /// </summary>
        ~CrossAppDomainObjRef()
        {
          Debug.Assert(IsFromThisProcess());
          Debug.Assert(IsFromThisAppDomain() == false);
          //Decrement ref counter
          CrossAppDomainObject remoteObject = (CrossAppDomainObject)GetRealObject(new StreamingContext(StreamingContextStates.CrossAppDomain));
          remoteObject.AppDomainDisconnect();
        }
    
        /// <summary>
        /// Populates a specified System.Runtime.Serialization.SerializationInfo with
        /// the data needed to serialize the current System.Runtime.Remoting.ObjRef instance.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo to populate with data.</param>
        /// <param name="context">The contextual information about the source or destination of the serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
          Debug.Assert(context.State == StreamingContextStates.CrossAppDomain);
          base.GetObjectData(info, context);
          info.SetType(typeof(CrossAppDomainObjRef));
        }
      }
