    MethodInfo mi = typeof(AuditLogger).GetMethod("GetAuditLogRecord");
    Type[] genericArguments = new Type[] { original.GetType() };
    MethodInfo genericMI = mi.MakeGenericMethod(genericArguments);
    AuditLog au = 
        (AuditLog)genericMI.Invoke(
            null, new object[] { original, update, "", userName });
