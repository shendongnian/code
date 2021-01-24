        #region IContractBehavior Members
        public void AddBindingParameters(ContractDescription description, ServiceEndpoint endpoint, BindingParameterCollection parameters)
        {
        }
        public void ApplyClientBehavior(ContractDescription description, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime proxy)
        {
            foreach (OperationDescription opDesc in description.Operations)
            {
                ApplyDataContractSurrogate(opDesc);
            }
        }
        public void ApplyDispatchBehavior(ContractDescription description, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatch)
        {
            foreach (OperationDescription opDesc in description.Operations)
            {
                ApplyDataContractSurrogate(opDesc);
            }
        }
        public void Validate(ContractDescription description, ServiceEndpoint endpoint)
        {
        }
        #endregion
        #region IWsdlExportExtension Members
        public void ExportContract(WsdlExporter exporter, WsdlContractConversionContext context)
        {
            if (exporter == null)
                throw new ArgumentNullException("exporter");
            object dataContractExporter;
            XsdDataContractExporter xsdDCExporter;
            if (!exporter.State.TryGetValue(typeof(XsdDataContractExporter), out dataContractExporter))
            {
                xsdDCExporter = new XsdDataContractExporter(exporter.GeneratedXmlSchemas);
                exporter.State.Add(typeof(XsdDataContractExporter), xsdDCExporter);
            }
            else
            {
                xsdDCExporter = (XsdDataContractExporter)dataContractExporter;
            }
            if (xsdDCExporter.Options == null)
                xsdDCExporter.Options = new ExportOptions();
            if (xsdDCExporter.Options.DataContractSurrogate == null)
                xsdDCExporter.Options.DataContractSurrogate = new DataContractOperationResultAttribute();
        }
        public void ExportEndpoint(WsdlExporter exporter, WsdlEndpointConversionContext context)
        {
        }
        #endregion
        #region IOperationBehavior Members
        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
        }
        public void ApplyClientBehavior(OperationDescription description, System.ServiceModel.Dispatcher.ClientOperation proxy)
        {
            ApplyDataContractSurrogate(description);
        }
        public void ApplyDispatchBehavior(OperationDescription description, System.ServiceModel.Dispatcher.DispatchOperation dispatch)
        {
            ApplyDataContractSurrogate(description);
        }
        public void Validate(OperationDescription description)
        {
        }
        #endregion
        private static void ApplyDataContractSurrogate(OperationDescription description)
        {
            DataContractSerializerOperationBehavior dcsOperationBehavior = description.Behaviors.Find<DataContractSerializerOperationBehavior>();
            if (dcsOperationBehavior != null)
            {
                if (dcsOperationBehavior.DataContractSurrogate == null)
                    dcsOperationBehavior.DataContractSurrogate = new DataContractOperationResultAttribute();
            }
        }
        #region IDataContractSurrogate Members
        public Type GetDataContractType(Type type)
        {
            // This method is called during serialization and schema export
            System.Diagnostics.Debug.WriteLine("GetDataContractType " + type.FullName);
            if (typeof(TestMethod1Ouput).IsAssignableFrom(type))
            {
                return typeof(OperationResult<int>);
            }
            if (typeof(TestMethod2Ouput).IsAssignableFrom(type))
            {
                return typeof(OperationResult<string>);
            }
            return type;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            //This method is called on serialization.
            System.Diagnostics.Debug.WriteLine("GetObjectToSerialize " + targetType.FullName);
            if (obj is TestMethod1Ouput)
            {
                return new OperationResult<int> { Result = ((TestMethod1Ouput)obj).OrginalResult, Error = string.Empty };
            }
            if (obj is TestMethod2Ouput)
            {
                return new OperationResult<string> { Result = ((TestMethod2Ouput)obj).OrginalResult, Error = string.Empty };
            }
            return obj;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }
        public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
        }
        #endregion
    }
