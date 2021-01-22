        static public void SetIdle(object request)
        {
            MethodInfo getConnectionGroupLine = request.GetType().GetMethod("GetConnectionGroupLine", BindingFlags.Instance | BindingFlags.NonPublic);
            string connectionName = (string)getConnectionGroupLine.Invoke(request, null);
            ServicePoint servicePoint = ((HttpWebRequest)request).ServicePoint;
            MethodInfo findConnectionGroup = servicePoint.GetType().GetMethod("FindConnectionGroup", BindingFlags.Instance | BindingFlags.NonPublic);
            object connectionGroup;
            lock (servicePoint)
            {
                connectionGroup = findConnectionGroup.Invoke(servicePoint, new object[] { connectionName, false });
            }
            PropertyInfo currentConnections = connectionGroup.GetType().GetProperty("CurrentConnections", BindingFlags.Instance | BindingFlags.NonPublic);
            PropertyInfo connectionLimit = connectionGroup.GetType().GetProperty("ConnectionLimit", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo disableKeepAliveOnConnections = connectionGroup.GetType().GetMethod("DisableKeepAliveOnConnections", BindingFlags.Instance | BindingFlags.NonPublic);
            if (((int)currentConnections.GetValue(connectionGroup, null)) ==
                ((int)connectionLimit.GetValue(connectionGroup, null)))
            {
                disableKeepAliveOnConnections.Invoke(connectionGroup, null);
            }
            MethodInfo connectionGoneIdle = connectionGroup.GetType().GetMethod("ConnectionGoneIdle", BindingFlags.Instance | BindingFlags.NonPublic);
            connectionGoneIdle.Invoke(connectionGroup, null);
        }
