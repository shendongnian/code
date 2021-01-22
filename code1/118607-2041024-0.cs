        private static void SetChannelProxy(HttpClientChannel channel, IWebProxy proxy)
        {
            FieldInfo proxyObjectFieldInfo = typeof(HttpClientChannel).GetField("_proxyObject", BindingFlags.Instance | BindingFlags.NonPublic);
            proxyObjectFieldInfo.SetValue(channel, proxy);
        }
