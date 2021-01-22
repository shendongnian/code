    static ClientExtensions : class
    {
        private delegate string MyDelegate(IClient, object);
        private static Dictionary<Type, MyDelegate> myDictionary
            = new Dictionary<Type, MyDelegate>();
        /// <summary>Static Contstructor</summary>
        static MyExtenderType()
        {
            myDictionary.Add(typeof(ClientA), SaveObjectAExtensionMethod);
            myDictionary.Add(typeof(ClientB), SaveObjectBExtensionMethod);
            myDictionary.Add(typeof(ClientC), SaveObjectCExtensionMethod);
            myDictionary.Add(typeof(ClientD), SaveObjectDExtensionMethod);
        }
        // TODO: copy for B, C & D
        public static string SaveObjectAExtensionMethod(this IClient client, object obj)
        {
            return client.SaveObjectA(obj);
        }
        public static string SaveObject(this IClient client, object obj)
        {
            MyDelegate dele;
            if (this.myDictionary.TryGetValue(typeof(client), out dele))
                return dele(client, obj);
            throw new NotSupported...
        }
    }
