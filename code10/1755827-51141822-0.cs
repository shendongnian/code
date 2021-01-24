                //Logging Actions
                if (request.Path != "/")
                {
                    if (request.Method == "POST")
                    {
                        Type T = _postDictionary[path];
                        MethodInfo methodLogAction = typeof(LoggingMiddleware).GetMethod("LogAction", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {typeof(object)}, null);
                        MethodInfo generic = methodLogAction.MakeGenericMethod(T);
                        generic.Invoke(this, new object[]{contextDto});
                    }
                }
