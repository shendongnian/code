    using System;
    using System.ServiceModel.Description;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    using System.Reflection;
    
        [AttributeUsage(AttributeTargets.Method)]
        public class MyCacheRegister : Attribute, IOperationBehavior
        {
            ConstructorInfo _chacherImplementation;
            public ImageCache(Type provider)
            {
                if (provider == null)
                {
                    throw new ArgumentNullException("Provider can't be null");
                }
                else if (provider.IsAssignableFrom(typeof(IOperationInvoker)))
                {
                    throw new ArgumentException("The type " + provider.AssemblyQualifiedName + " does not implements the interface " + typeof(IOperationInvoker).AssemblyQualifiedName);
                }
                else
                {
                    try
                    {
                        Type[] constructorSignatureTypes = new Type[1];
                        constructorSignatureTypes[0] = typeof(IOperationInvoker);
                        _chacherImplementation = provider.GetConstructor(constructorSignatureTypes);
    
                    }
                    catch
                    {
                        throw new ArgumentException("There is no constructor in " + provider.AssemblyQualifiedName + " that accept " + typeof(IOperationInvoker).AssemblyQualifiedName + " as a parameter");
                    }
    
                }
    
    
            }
    
            public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
            {
                return;
            }
    
            public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
            {
                return;
            }
    
            /// <summary>
            /// Decorate the method call with the cacher
            /// </summary>
            public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
                //decorator pattern, decorate with a  cacher
                object[] constructorParam = new object[1];
                constructorParam[0] = dispatchOperation.Invoker;
                dispatchOperation.Invoker = (IOperationInvoker)_chacherImplementation.Invoke(constructorParam);
            }
    
            public void Validate(OperationDescription operationDescription)
            {
                return;
            }
        }
