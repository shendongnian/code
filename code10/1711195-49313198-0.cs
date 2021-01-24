        var functions = Dictionary<Type, Action<dynamic>>();
        void RegisterDynamicHandler<T>(Action<dynamic> handler)
        {
            Functions.Add(typeof(T), handler);
        }
        public void RegisterHandler<T>(Action<T> handler)
            where T : BaseClass
        {
            if (functions.ContainsKey(typeof(T)))
                throw new RegisterHandlerException();
            Action<dynamic> dynamicAction = (Action<dynamic>)handler;
            RegisterDynamicHandler<T>(dynamicAction);
        }
