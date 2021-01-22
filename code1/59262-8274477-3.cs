    using System;
    using System.ServiceModel.Dispatcher;
    using Microsoft.Practices.EnterpriseLibrary.Caching;
    using Microsoft.Practices.EnterpriseLibrary.Common;
    using System.IO;
    
        class RotateCacher : IOperationInvoker
        {
    
            private IOperationInvoker _innerOperationInvoker;
            public RotateImageCacher(IOperationInvoker innerInvoker)
            {
                _innerOperationInvoker = innerInvoker;
            }
            public object[] AllocateInputs()
            {
                Object[] result = _innerOperationInvoker.AllocateInputs();
                return result;
            }
    
            public object Invoke(object instance, object[] inputs, out object[] outputs)
            {
                object result=null;
    
    ///TODO: You will have more object in the input if you have more ///parameters in your method
    
                string angle = inputs[1].ToString();
                
                ///TODO: create a unique key from the inputs
                string key = angle;
    
                string provider = System.Configuration.ConfigurationManager.AppSettings["CacheProviderName"];
                ///Important Provider will be DiskCache or MemoryCache for the moment
    provider =”DiskCache”;
    ///TODO: call enterprise library cache manager, You can have your own 
    /// custom cache like Hashtable
    
        ICacheManager manager = CacheFactory.GetCacheManager(provider);
    
                if (manager.Contains(key))
                {
                     
                    result =(MyCompositeClass) manager[key];
    
                }
                else
                {
                    result =(MyCompositeClass) _innerOperationInvoker.Invoke(instance, inputs, out outputs);
                    manager.Add(key, result);
                }
                return result;
            }
    
            public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
            {
                IAsyncResult result = _innerOperationInvoker.InvokeBegin(instance, inputs, callback, state);
                return result;
            }
    
            public object InvokeEnd(object instance, out object[] outputs, IAsyncResult asyncResult)
            {
                object result = _innerOperationInvoker.InvokeEnd(instance, out outputs, asyncResult);
                return result;
            }
    
            public bool IsSynchronous
            {
                get { return _innerOperationInvoker.IsSynchronous; }
            }
        }
