    /// <summary>
    /// A class to use for single-instance applications.
    /// </summary>
    public static class SingleInstanceManager
    {
      /// <summary>
      /// Raised when another instance attempts to start up.
      /// </summary>
      public static event StartupEventHandler OtherInstanceStarted;
  
      /// <summary>
      /// Checks to see if this instance is the first instance running on this machine.  If it is not, this method will
      /// send the main instance this instance's startup information.
      /// </summary>
      /// <param name="guid">The application's unique identifier.</param>
      /// <returns>True if this instance is the main instance.</returns>
      public static bool VerifySingleInstace(Guid guid)
      {
        if (!AttemptPublishService(guid))
        {
          NotifyMainInstance(guid);
  
          return false;
        }
  
        return true;
      }
  
      /// <summary>
      /// Attempts to publish the service.
      /// </summary>
      /// <param name="guid">The application's unique identifier.</param>
      /// <returns>True if the service was published successfully.</returns>
      private static bool AttemptPublishService(Guid guid)
      {
        try
        {
          ServiceHost serviceHost = new ServiceHost(typeof(SingleInstance));
          NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
          serviceHost.AddServiceEndpoint(typeof(ISingleInstance), binding, CreateAddress(guid));
          serviceHost.Open();
  
          return true;
        }
        catch
        {
          return false;
        }
      }
  
      /// <summary>
      /// Notifies the main instance that this instance is attempting to start up.
      /// </summary>
      /// <param name="guid">The application's unique identifier.</param>
      private static void NotifyMainInstance(Guid guid)
      {
        NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
        EndpointAddress remoteAddress = new EndpointAddress(CreateAddress(guid));
        using (ChannelFactory<ISingleInstance> factory = new ChannelFactory<ISingleInstance>(binding, remoteAddress))
        {
          ISingleInstance singleInstance = factory.CreateChannel();
          singleInstance.NotifyMainInstance(Environment.GetCommandLineArgs());
        }
      }
  
      /// <summary>
      /// Creates an address to publish/contact the service at based on a globally unique identifier.
      /// </summary>
      /// <param name="guid">The identifier for the application.</param>
      /// <returns>The address to publish/contact the service.</returns>
      private static string CreateAddress(Guid guid)
      {
        return string.Format(CultureInfo.CurrentCulture, "net.pipe://localhost/{0}", guid);
      }
  
      /// <summary>
      /// The interface that describes the single instance service.
      /// </summary>
      [ServiceContract]
      private interface ISingleInstance
      {
        /// <summary>
        /// Notifies the main instance that another instance of the application attempted to start.
        /// </summary>
        /// <param name="args">The other instance's command-line arguments.</param>
        [OperationContract]
        void NotifyMainInstance(string[] args);
      }
  
      /// <summary>
      /// The implementation of the single instance service interface.
      /// </summary>
      private class SingleInstance : ISingleInstance
      {
        /// <summary>
        /// Notifies the main instance that another instance of the application attempted to start.
        /// </summary>
        /// <param name="args">The other instance's command-line arguments.</param>
        public void NotifyMainInstance(string[] args)
        {
          if (OtherInstanceStarted != null)
          {
            Type type = typeof(StartupEventArgs);
            ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
            StartupEventArgs e = (StartupEventArgs)constructor.Invoke(null);
            FieldInfo argsField = type.GetField("_args", BindingFlags.Instance | BindingFlags.NonPublic);
            Debug.Assert(argsField != null);
            argsField.SetValue(e, args);
  
            OtherInstanceStarted(null, e);
          }
        }
      }
    }
