	&lt;system.serviceModel&gt;
    &lt;extensions&gt;
      &lt;bindingElementExtensions&gt;
        &lt;add name="pollingDuplex"
             type="System.ServiceModel.Configuration.PollingDuplexElement, System.ServiceModel.PollingDuplex"/&gt;
      &lt;/bindingElementExtensions&gt;
    &lt;/extensions&gt;
    
		&lt;bindings&gt;
			&lt;customBinding&gt;
				&lt;binding name="DuplexConfig"&gt;
					&lt;binaryMessageEncoding/&gt;
					&lt;pollingDuplex maxPendingSessions="2147483647" maxPendingMessagesPerSession="2147483647" inactivityTimeout="02:00:00" serverPollTimeout="00:05:00"/&gt;
					&lt;httpTransport/&gt;
				&lt;/binding&gt;
			&lt;/customBinding&gt;
		&lt;/bindings&gt;
    
		&lt;behaviors&gt;
			&lt;serviceBehaviors&gt;
				&lt;behavior name="CTC.Test.WCF.Server.DuplexServiceBehavior"&gt;
					&lt;serviceMetadata httpGetEnabled="true"/&gt;
					&lt;serviceDebug includeExceptionDetailInFaults="true"/&gt;
					&lt;serviceThrottling maxConcurrentSessions="2147483647"/&gt;
				&lt;/behavior&gt;
			&lt;/serviceBehaviors&gt;
		&lt;/behaviors&gt;
    
		&lt;services&gt;
			&lt;service behaviorConfiguration="CTC.Test.WCF.Server.DuplexServiceBehavior" name="CTC.Test.WCF.Server.DuplexService"&gt;
				&lt;endpoint address="" binding="customBinding" bindingConfiguration="DuplexConfig" contract="CTC.Test.WCF.Server.IDuplexService"/&gt;
				&lt;endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange"/&gt;
			&lt;/service&gt;
		&lt;/services&gt;
    
	&lt;/system.serviceModel&gt;
	
	
	&lt;
