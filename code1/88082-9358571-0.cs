    /// <summary>Copying the attributes of a type to a new type</summary>
    private static void copyAttributes<TMessage>(TypeBuilder dynamictype)
    {
        try
        {
            //Iterate over all attributes of the TMessage class and copy these to the new type
            IList<CustomAttributeData> attributes = CustomAttributeData.GetCustomAttributes(typeof(TMessage));
            if (attributes != null)
            {
              foreach (CustomAttributeData attribute in attributes)
              {
                  List<object> constructorarguments = new List<object>();
                  if (attribute.ConstructorArguments != null)
                  {
                      foreach (CustomAttributeTypedArgument argument in attribute.ConstructorArguments)
                      {
                          constructorarguments.Add(argument.Value);
                      }
                  }
                  List<FieldInfo> namedfields = new List<FieldInfo>();
                  List<object> namedfieldarguments = new List<object>();
                  List<PropertyInfo> namedproperties = new List<PropertyInfo>();
                  List<object> namedpropertyarguments = new List<object>();
                  if (attribute.NamedArguments != null)
                  {
                      //Iterate over all named arguments
                      foreach (CustomAttributeNamedArgument argument in attribute.NamedArguments)
                      {
                          //Check which type of argument is found
                          if (argument.MemberInfo is FieldInfo)
                          {
                              FieldInfo field = argument.MemberInfo as FieldInfo;
                              namedfields.Add(field);
                              namedfieldarguments.Add(argument.TypedValue.Value);
                          }
                          else if (argument.MemberInfo is PropertyInfo)
                          {
                              PropertyInfo property = argument.MemberInfo as PropertyInfo;
                              namedproperties.Add(property);
                              namedpropertyarguments.Add(argument.TypedValue.Value);
                          }
                      }
                  }
                  //Check if the current attribute is of type XmlRoot.
                  //In this case the ElementName or TypeName property must also be set
                  if (attribute.Constructor.DeclaringType.Equals(typeof(XmlRootAttribute)))
                  {
                      namedproperties.Add(typeof(XmlRootAttribute).GetProperty("ElementName"));
                      namedpropertyarguments.Add(typeof(TMessage).Name);
                  }
                  //Build the copy of the parent attribute
                  CustomAttributeBuilder copyattributebuilder = new CustomAttributeBuilder(
                      attribute.Constructor,
                      constructorarguments.ToArray(),
                      namedproperties.ToArray(),
                      namedpropertyarguments.ToArray(),
                      namedfields.ToArray(),
                      namedfieldarguments.ToArray());
                  //Add the attribute to the dynamic type
                  dynamictype.SetCustomAttribute(copyattributebuilder);
              }
          }
      }
      catch (Exception exception)
      {
          throw new ApplicationException("Unable to copy attribute from parent type", exception);
      }
    }
    /// <summary>Create dynamic type for an operation message which includes the types for serialization</summary>
    /// <returns>Returns dynamic type</returns>
    public static Type CreateMessageType<TMessage>()
    {
        try
        {
            AssemblyBuilder assemblybuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
                ModuleBuilder modulebuilder = assemblybuilder.DefineDynamicModule(Guid.NewGuid().ToString(), false);
                //Create type based on an unique so that it does not conflict with the OperationMessage classname
                TypeBuilder typebuilder = modulebuilder.DefineType(typeof(TMessage).Name + "Dynamic", TypeAttributes.Public | TypeAttributes.Class);
                //Set original message type as parent of the new dynamic type
                typebuilder.SetParent(typeof(TMessage));
                //Copy attributes from TMessage paren type to the dynamic type
                WMQXMLMessageTypeFactory.copyAttributes<TMessage>(typebuilder);
                //Create the xsi:schemaLocation property
                CustomAttributeBuilder attributebuilder = new CustomAttributeBuilder(
                    typeof(XmlAttributeAttribute).GetConstructor(new Type[] { typeof(string) }),
                    new object[] { "schemaLocation" },
                    new PropertyInfo[] { typeof(XmlAttributeAttribute).GetProperty("Namespace") },
                    new object[] { XmlSchema.InstanceNamespace });
                FieldBuilder schemalocationfieldbuilder = typebuilder.DefineField("SchemaLocation", typeof(string), FieldAttributes.Public);
                schemalocationfieldbuilder.SetCustomAttribute(attributebuilder);
                return typebuilder.CreateType();
            }
            catch (Exception exception)
            {
                throw new ApplicationException("Unable to create XML message type", exception);
            }
        }
