    log4net: Setting Collection Property [AddParameter] to object [MicroKnights.Logging.AdoNetAppenderParameter]
    log4net:ERROR [AdoNetAppender] ErrorCode: GenericFailure. Failed to load connection type [System.Data.SqlClient.SqlConnection, System.Data, Version=4.4.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]
    System.IO.FileLoadException: Could not load file or assembly 'System.Data, Version=4.4.0.65535, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
    File name: 'System.Data, Version=4.4.0.65535, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
       at System.RuntimeTypeHandle.GetTypeByName(String name, Boolean throwOnError, Boolean ignoreCase, Boolean reflectionOnly, StackCrawlMarkHandle stackMark, IntPtr pPrivHostBinder, Boolean loadTypeFromPartialName, ObjectHandleOnStack type, ObjectHandleOnStack keepalive)
       at System.RuntimeTypeHandle.GetTypeByName(String name, Boolean throwOnError, Boolean ignoreCase, Boolean reflectionOnly, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean loadTypeFromPartialName)
       at System.RuntimeType.GetType(String typeName, Boolean throwOnError, Boolean ignoreCase, Boolean reflectionOnly, StackCrawlMark& stackMark)
       at System.Type.GetType(String typeName, Boolean throwOnError, Boolean ignoreCase)
       at log4net.Util.SystemInfo.GetTypeFromString(Assembly relativeAssembly, String typeName, Boolean throwOnError, Boolean ignoreCase)
       at MicroKnights.Logging.AdoNetAppender.ResolveConnectionType()
