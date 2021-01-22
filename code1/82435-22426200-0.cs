    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    public static class ObservableFactory
    {
        public static T Create<T>(T target)
        {
            if (!typeof(T).IsInterface)
                throw new ArgumentException("Target should be an interface", "target");
            var proxy = new Observable<T>(target);
            return (T)proxy.GetTransparentProxy();
        }
    }
    internal class Observable<T> : RealProxy, INotifyPropertyChanged, INotifyPropertyChanging
    {
        private readonly T target;
        internal Observable(T target)
            : base(ImplementINotify(typeof(T)))
        {
            this.target = target;
        }
        
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            if (methodCall != null)
            {
                return HandleMethodCall(methodCall);
            }
            return null;
        }
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        
        IMessage HandleMethodCall(IMethodCallMessage methodCall)
        {
            var isPropertySetterCall = methodCall.MethodName.StartsWith("set_");
            var propertyName = isPropertySetterCall ? methodCall.MethodName.Substring(4) : null;
            if (isPropertySetterCall)
            {
                OnPropertyChanging(propertyName);
            }
            try
            {
                object methodCalltarget = target;
                if (methodCall.MethodName == "add_PropertyChanged" || methodCall.MethodName == "remove_PropertyChanged"||
                    methodCall.MethodName == "add_PropertyChanging" || methodCall.MethodName == "remove_PropertyChanging")
                {
                    methodCalltarget = this;
                }
                var result = methodCall.MethodBase.Invoke(methodCalltarget, methodCall.InArgs);
                if (isPropertySetterCall)
                {
                    OnPropertyChanged(methodCall.MethodName.Substring(4));
                }
                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (TargetInvocationException invocationException)
            {
                var exception = invocationException.InnerException;
                return new ReturnMessage(exception, methodCall);
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanging(string propertyName)
        {
            var handler = PropertyChanging;
            if (handler != null) handler(this, new PropertyChangingEventArgs(propertyName));
        }
        public static Type ImplementINotify(Type objectType)
        {
            var tempAssemblyName = new AssemblyName(Guid.NewGuid().ToString());
            var dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
                tempAssemblyName, AssemblyBuilderAccess.RunAndCollect);
            var moduleBuilder = dynamicAssembly.DefineDynamicModule(
                tempAssemblyName.Name,
                tempAssemblyName + ".dll");
            var typeBuilder = moduleBuilder.DefineType(
                objectType.FullName, TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract);
            typeBuilder.AddInterfaceImplementation(objectType);
            typeBuilder.AddInterfaceImplementation(typeof(INotifyPropertyChanged));
            typeBuilder.AddInterfaceImplementation(typeof(INotifyPropertyChanging));
            var newType = typeBuilder.CreateType();
            return newType;
        }
    }
}
