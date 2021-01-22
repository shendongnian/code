    static class IpcChannelManager<T> {
       /// <summary>
       /// Make a type available to other processess
       /// </summary>
       /// <param name="type">
       /// Type to register, must derive from MarshalByRefObject and implement <typeparamref name="T"/>
       /// </param>
       /// <param name="portName">Name of IpcChannel</param>
       public static void RegisterType(Type type, string portName) {
           if (!type.IsSubclassOf(typeof(MarshalByRefObject)))
               throw new ArgumentException("Registered type must derive from MarshalByRefObject");
           Dictionary<string, string> ipcproperties = new Dictionary<string, string>();
           ipcproperties["portName"] = portName;
           // Get the localized name of the "Authenticated users" group
           ipcproperties["authorizedGroup"] = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null).Translate(typeof(NTAccount)).ToString();
            ChannelServices.RegisterChannel(new IpcServerChannel(ipcproperties, null), false);
            RemotingConfiguration.RegisterWellKnownServiceType(type, typeof(T).Name, WellKnownObjectMode.Singleton);
        }
        /// <summary>
        /// Get a reference to a remoting object
        /// </summary>
        /// <param name="portName">Name of Ipc port</param>
        /// <returns>
        /// Reference to remote server object</returns>
        public static T GetRemoteProxy(string portName) {
            ChannelServices.RegisterChannel(new IpcClientChannel(), false);
            return (T)Activator.GetObject(typeof(T), "ipc://" + portName + "/" + typeof(T).Name);
    }
