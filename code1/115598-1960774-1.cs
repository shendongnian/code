    public class ReflectionEmitPropertyAccessor
    	{
    		private readonly bool canRead;
    		private readonly bool canWrite;
    		private IPropertyAccessor emittedPropertyAccessor;
    		private readonly string propertyName;
    		private readonly Type propertyType;
    		private readonly Type targetType;
    		private Dictionary<Type,OpCode> typeOpCodes;
    
    		public ReflectionEmitPropertyAccessor(Type targetType, string property)
    		{
    			this.targetType = targetType;
    			propertyName = property;
                var propertyInfo = targetType.GetProperty(property);
    			if (propertyInfo == null)
    			{
    				throw new ReflectionOptimizerException(string.Format("Property \"{0}\" is not found in type "+ "{1}.", property, targetType));
    			}
    			canRead = propertyInfo.CanRead;
    			canWrite = propertyInfo.CanWrite;
    			propertyType = propertyInfo.PropertyType;
    		}
    
    		public bool CanRead
    		{
    			get { return canRead; }
    		}
    
    		public bool CanWrite
    		{
    			get { return canWrite; }
    		}
    
    		public Type TargetType
    		{
    			get { return targetType; }
    		}
    
    		public Type PropertyType
    		{
    			get { return propertyType; }
    		}
    
    		#region IPropertyAccessor Members
    
    		public object Get(object target)
    		{
    			if (canRead)
    			{
    				if (emittedPropertyAccessor == null)
    				{
    					Init();
    				}
    
    				if (emittedPropertyAccessor != null) return emittedPropertyAccessor.Get(target);
    				
    			}
    			else
    			{
    				throw new ReflectionOptimizerException(string.Format("У свойства \"{0}\" нет метода get.", propertyName));
    			}
    			throw new ReflectionOptimizerException("Fail initialize of " + GetType().FullName);
    		}
    
    		public void Set(object target, object value)
    		{
    			if (canWrite)
    			{
    				if (emittedPropertyAccessor == null)
    				{
    					Init();
    				}
    				if (emittedPropertyAccessor != null) emittedPropertyAccessor.Set(target, value);
    			}
    			else
    			{
    				throw new ReflectionOptimizerException(string.Format("Property \"{0}\" does not have method set.", propertyName));
    			}
    			throw new ReflectionOptimizerException("Fail initialize of " + GetType().FullName);
    		}
    
    		#endregion
    
    		private void Init()
    		{
    			InitTypeOpCodes();
    			var assembly = EmitAssembly();
    			emittedPropertyAccessor = assembly.CreateInstance("Property") as IPropertyAccessor;
                if (emittedPropertyAccessor == null)
    			{
    				throw new ReflectionOptimizerException("Shit happense in PropertyAccessor.");
    			}
    		}
    
    		private void InitTypeOpCodes()
    		{
    			typeOpCodes = new Dictionary<Type, OpCode>
    			              	{
    			              		{typeof (sbyte), OpCodes.Ldind_I1},
    			              		{typeof (byte), OpCodes.Ldind_U1},
    			              		{typeof (char), OpCodes.Ldind_U2},
    			              		{typeof (short), OpCodes.Ldind_I2},
    			              		{typeof (ushort), OpCodes.Ldind_U2},
    			              		{typeof (int), OpCodes.Ldind_I4},
    			              		{typeof (uint), OpCodes.Ldind_U4},
    			              		{typeof (long), OpCodes.Ldind_I8},
    			              		{typeof (ulong), OpCodes.Ldind_I8},
    			              		{typeof (bool), OpCodes.Ldind_I1},
    			              		{typeof (double), OpCodes.Ldind_R8},
    			              		{typeof (float), OpCodes.Ldind_R4}
    			              	};
    		}
    
    		private Assembly EmitAssembly()
    		{
    			var assemblyName = new AssemblyName {Name = "PropertyAccessorAssembly"};
    			var newAssembly = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
    			var newModule = newAssembly.DefineDynamicModule("Module");
    			var dynamicType = newModule.DefineType("Property", TypeAttributes.Public);
                dynamicType.AddInterfaceImplementation(typeof(IPropertyAccessor));
                dynamicType.DefineDefaultConstructor(MethodAttributes.Public);
    			var getParamTypes = new[] { typeof(object) };
    			var getReturnType = typeof(object);
    			var getMethod = dynamicType.DefineMethod("Get",
    									MethodAttributes.Public | MethodAttributes.Virtual,
    									getReturnType,
    									getParamTypes);
    
    			var getIL = getMethod.GetILGenerator();
                var targetGetMethod = targetType.GetMethod("get_" + propertyName);
    
    			if (targetGetMethod != null)
    			{
    				getIL.DeclareLocal(typeof(object));
    				getIL.Emit(OpCodes.Ldarg_1); //Load the first argument 
    				getIL.Emit(OpCodes.Castclass, targetType); //Cast to the source type
                    getIL.EmitCall(OpCodes.Call, targetGetMethod, null); //Get the property value
                    if (targetGetMethod.ReturnType.IsValueType)
    				{
    					getIL.Emit(OpCodes.Box, targetGetMethod.ReturnType); //Box
    				}
    				getIL.Emit(OpCodes.Stloc_0); //Store it
                    getIL.Emit(OpCodes.Ldloc_0);
    			}
    			else
    			{
    				getIL.ThrowException(typeof(MissingMethodException));
    			}
    
    			getIL.Emit(OpCodes.Ret);
    			var setParamTypes = new[] { typeof(object), typeof(object) };
    			const Type setReturnType = null;
    			var setMethod = dynamicType.DefineMethod("Set",
    									MethodAttributes.Public | MethodAttributes.Virtual,
    									setReturnType,
    									setParamTypes);
    
    			var setIL = setMethod.GetILGenerator();
    			
    			var targetSetMethod = targetType.GetMethod("set_" + propertyName);
    			if (targetSetMethod != null)
    			{
    				Type paramType = targetSetMethod.GetParameters()[0].ParameterType;
    
    				setIL.DeclareLocal(paramType);
    				setIL.Emit(OpCodes.Ldarg_1); //Load the first argument //(target object)
                    setIL.Emit(OpCodes.Castclass, targetType); //Cast to the source type
                    setIL.Emit(OpCodes.Ldarg_2); //Load the second argument 
    				//(value object)
                    if (paramType.IsValueType)
    				{
    					setIL.Emit(OpCodes.Unbox, paramType); //Unbox it 	
    					if (typeOpCodes.ContainsKey(paramType)) //and load
    					{
    						var load = typeOpCodes[paramType];
    						setIL.Emit(load);
    					}
    					else
    					{
    						setIL.Emit(OpCodes.Ldobj, paramType);
    					}
    				}
    				else
    				{
    					setIL.Emit(OpCodes.Castclass, paramType); //Cast class
    				}
                    setIL.EmitCall(OpCodes.Callvirt,targetSetMethod, null); //Set the property value
    			}
    			else
    			{
    				setIL.ThrowException(typeof(MissingMethodException));
    			}
                setIL.Emit(OpCodes.Ret);
                // Load the type
    			dynamicType.CreateType();
                return newAssembly;
    		}
    
    	}
