    This is because you are getting the error:
    
    System.Runtime.Serialization.InvalidDataContractException: Type 'System.Windows.Forms.Menu' cannot be serialized.
    
    See browser exception detail:
    
    An ExceptionDetail, likely created by IncludeExceptionDetailInFaults=true, whose value is:
    System.InvalidOperationException: An exception was thrown in a call to a WSDL export extension: System.ServiceModel.Description.DataContractSerializerOperationBehavior
     contract: http://tempuri.org/:iSEMSIntegrationWCFService ----> System.Runtime.Serialization.InvalidDataContractException: Type 'System.Windows.Forms.Menu' cannot be serialized. Consider marking it with the DataContractAttribute attribute, and marking all of its members you want serialized with the DataMemberAttribute attribute.  If the type is a collection, consider marking it with the CollectionDataContractAttribute.  See the Microsoft .NET Framework documentation for other supported types.
       at System.Runtime.Serialization.DataContract.DataContractCriticalHelper.ThrowInvalidDataContractException(String message, Type type)
       at System.Runtime.Serialization.DataContract.DataContractCriticalHelper.CreateDataContract(Int32 id, RuntimeTypeHandle typeHandle, Type type)
       at System.Runtime.Serialization.DataContract.DataContractCriticalHelper.GetDataContractSkipValidation(Int32 id, RuntimeTypeHandle typeHandle, Type type)
       at System.Runtime.Serialization.ClassDataContract.ClassDataContractCriticalHelper..ctor(Type type)
       at System.Runtime.Serialization.DataContract.DataContractCriticalHelper.CreateDataContract(Int32 id, RuntimeTypeHandle typeHandle, Type type)
       at System.Runtime.Serialization.DataContract.DataContractCriticalHelper.GetDataContractSkipValidation(Int32 id, RuntimeTypeHandle typeHandle, Type type)
       at System.Runtime.Serialization.DataContractSet.GetDataContract(Type clrType)
       at System.Runtime.Serialization.DataContractSet.GetMemberTypeDataContract(DataMember dataMember)
       at System.Runtime.Serialization.DataContractSet.AddClassDataContract(ClassDataContract classDataContract)
       at System.Runtime.Serialization.DataContractSet.InternalAdd(XmlQualifiedName name, DataContract dataContract)
       at System.Runtime.Serialization.DataContractSet.AddClassDataContract(ClassDataContract classDataContract)
       at System.Runtime.Serialization.DataContractSet.InternalAdd(XmlQualifiedName name, DataContract dataContract)
       at System.Runtime.Serialization.DataContractSet.AddClassDataContract(ClassDataContract classDataContract)
       at System.Runtime.Serialization.DataContractSet.InternalAdd(XmlQualifiedName name, DataContract dataContract)
       at System.Runtime.Serialization.DataContractSet.AddClassDataContract(ClassDataContract classDataContract)
       at System.Runtime.Serialization.DataContractSet.InternalAdd(XmlQualifiedName name, DataContract dataContract)
       at System.Runtime.Serialization.DataContractSet.AddClassDataContract(ClassDataContract classDataContract)
       at System.Runtime.Serialization.DataContractSet.InternalAdd(XmlQualifiedName name, DataContract dataContract)
       at System.Runtime.Serialization.DataContractSet.AddClassDataContract(ClassDataContract classDataContract)
       at System.Runtime.Serialization.DataContractSet.InternalAdd(XmlQualifiedName name, DataContract dataContract)
       at System.Runtime.Serialization.DataContractSet.Add(Type type)
       at System.Runtime.Serialization.XsdDataContractExporter.Export(Type type)
       at System.ServiceModel.Description.MessageContractExporter.ExportType(Type type, String partName, String operationName, XmlSchemaType& xsdType)
       at System.ServiceModel.Description.DataContractSerializerMessageContractExporter.ExportBody(Int32 messageIndex, Object state)
       at System.ServiceModel.Description.MessageContractExporter.ExportMessage(Int32 messageIndex, Object state)
       at System.ServiceModel.Description.MessageContractExporter.ExportMessageContract()
       at System.ServiceModel.Description.DataContractSerializerOperationBehavior.System.ServiceModel.Description.IWsdlExportExtension.ExportContract(WsdlExporter exporter, WsdlContractConversionContext contractContext)
       at System.ServiceModel.Description.WsdlExporter.CallExtension(WsdlContractConversionContext contractContext, IWsdlExportExtension extension)
       --- End of inner ExceptionDetail stack trace ---
       at System.ServiceModel.Description.WsdlExporter.CallExtension(WsdlContractConversionContext contractContext, IWsdlExportExtension extension)
       at System.ServiceModel.Description.WsdlExporter.CallExportContract(WsdlContractConversionContext contractContext)
       at System.ServiceModel.Description.WsdlExporter.ExportContract(ContractDescription contract)
       at System.ServiceModel.Description.WsdlExporter.ExportEndpoint(ServiceEndpoint endpoint, XmlQualifiedName wsdlServiceQName, BindingParameterCollection bindingParameters)
       at System.ServiceModel.Description.WsdlExporter.ExportEndpoints(IEnumerable`1 endpoints, XmlQualifiedName wsdlServiceQName, BindingParameterCollection bindingParameters)
       at System.ServiceModel.Description.ServiceMetadataBehavior.MetadataExtensionInitializer.GenerateMetadata()
       at System.ServiceModel.Description.ServiceMetadataExtension.EnsureInitialized()
       at System.ServiceModel.Description.ServiceMetadataExtension.get_Metadata()
       at System.ServiceModel.Description.ServiceMetadataExtension.HttpGetImpl.InitializationData.InitializeFrom(ServiceMetadataExtension extension)
       at System.ServiceModel.Description.ServiceMetadataExtension.HttpGetImpl.GetInitData()
       at System.ServiceModel.Description.ServiceMetadataExtension.HttpGetImpl.TryHandleDocumentationRequest(Message httpGetRequest, String[] queries, Message& replyMessage)
       at System.ServiceModel.Description.ServiceMetadataExtension.HttpGetImpl.ProcessHttpRequest(Message httpGetRequest)
       at System.ServiceModel.Description.ServiceMetadataExtension.HttpGetImpl.Get(Message message)
       at SyncInvokeGet(Object , Object[] , Object[] )
       at System.ServiceModel.Dispatcher.SyncMethodInvoker.Invoke(Object instance, Object[] inputs, Object[]& outputs)
       at System.ServiceModel.Dispatcher.DispatchOperationRuntime.InvokeBegin(MessageRpc& rpc)
       at System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage5(MessageRpc& rpc)
       at System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage41(MessageRpc& rpc)
       at System.ServiceModel.Dispatcher.MessageRpc.Process(Boolean isOperationContextSet)
    
    
    Contract Definition:
    
    <system.serviceModel>
      <services>
        <service name="myService" behaviorConfiguration="MyDefaultBehaviour">
          <host>
            <baseAddresses>
              <add baseAddress="http://localhost:8880/MyOwnWCFService/" />
            </baseAddresses>
          </host>
    
          <endpoint
            address=""
            binding="basicHttpBinding"
            contract="iSEMSIntegrationWCFService" />
    
          <endpoint
            address="mex"
            binding="mexHttpBinding"
            contract="IMetaDataExchange" />
        </service>
      </services>
    
      <behaviors>
        <serviceBehaviors>
          <behavior name ="MyDefaultBehaviour">
            <serviceMetadata httpGetEnabled="true" httpsGetEnabled="false" />
            <serviceDebug includeExceptionDetailInFaults="true" />
            <serviceThrottling maxConcurrentCalls="1" />
          </behavior>
        </serviceBehaviors>
      </behaviors>
    </system.serviceModel>
