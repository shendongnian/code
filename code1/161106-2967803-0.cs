    public class SessionStore {
      /// <summary>
      /// Gets the current instance of <see cref="SessionStore" />.
      /// </summary>
      public static SessionStore Instance {
         get {
          return SessionStoreInternal.Instance;
        }
      }
    
      /// <summary>
      /// Supports lazy initialisation of a <see cref="SessionStore" /> instance.
      /// </summary>
      internal class SessionStoreInternal {
         /// <summary>
         /// The current instance of <see cref="SessionStore" />.
         /// </summary>
        internal static readonly SessionStore Instance = new SessionStore();
        /// <summary>
        /// Required to stop the Instance field being initialised through BeforeFieldInit     behaviour,
        /// allowing us to only initialise the field when it is accessed.
        /// </summary>
        static SessionStoreInternal() { }
      }
    }
