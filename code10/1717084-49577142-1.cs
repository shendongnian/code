    // Load policies from the configuration file.
    // SystemConfigurationSource is defined in 
    // Microsoft.Practices.EnterpriseLibrary.Common.
    using (var config = new SystemConfigurationSource())
    {
      var settings = RetryPolicyConfigurationSettings.GetRetryPolicySettings(config);
    
      // Initialize the RetryPolicyFactory with a RetryManager built from the 
      // settings in the configuration file.
      RetryPolicyFactory.SetRetryManager(settings.BuildRetryManager());
    
      var retryPolicy = RetryPolicyFactory.GetRetryPolicy
      <SqlDatabaseTransientErrorDetectionStrategy>("Incremental Retry Strategy");   
       ... 
       // Use the policy to handle the retries of an operation.
    
    }
