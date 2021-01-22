		public static T FindAndCreate<T>(bool localOnly, bool exportedOnly)
		{
			Type[] types = FindAssignableClasses(typeof(T), localOnly, exportedOnly, false);
			if (types.Length == 0)
			{
				return default(T);
			}
			if (types.Length != 1)
			{
				Log.Warn(typeof(ReflectionUtil),
						 "FindAndCreate found {0} instances of {1} whereas only 1 was expected.  Using {2}.  {3}",
						 types.Length,
						 typeof(T).FullName,
						 types[0].FullName,
						 String.Join("\r\n  ", Array.ConvertAll<Type, String>(types, GetFullName)));
			}
			try
			{
				return (T)Activator.CreateInstance(types[0]);
			}
			catch (Exception ex)
			{
				throw ExceptionUtil.Rethrow(ex,
											"Unable to create instance of {0} found for interface {1}.",
											types[0].FullName,
											typeof(T).FullName);
			}
		}
		public static Type[] FindAssignableClasses(Type assignable, bool localOnly, bool exportedOnly, bool loadDll)
		{
			var list = new List<Type>();
			string localDirectoryName = Path.GetDirectoryName(typeof(ReflectionUtil).Assembly.CodeBase);
			if (loadDll && !_loadedAllDlls)
			{
				foreach (string dllPath in Directory.GetFiles(localDirectoryName.Substring(6), "*.dll"))
				{
					try
					{
						Assembly.LoadFrom(dllPath);
					}
					catch
					{
						// ignore
					}
				}
				_loadedAllDlls = true;
			}
			foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
			{
				try
				{
					if (localOnly && Path.GetDirectoryName(asm.CodeBase) != localDirectoryName)
					{
						continue;
					}
				    Type[] typesInAssembly;
				    try
				    {
				        typesInAssembly = exportedOnly ? asm.GetExportedTypes() : asm.GetTypes();
				    }
				    catch
				    {
				        continue;
				    }
				    foreach (Type t in typesInAssembly)
					{
						try
						{
							if (assignable.IsAssignableFrom(t) && assignable != t)
							{
								list.Add(t);
							}
						}
						catch (Exception ex)
						{
							Log.Debug(
								typeof(ReflectionUtil),
								String.Format(
									"Error searching for types assignable to type {0} searching assembly {1} testing {2}{3}",
									assignable.FullName,
									asm.FullName,
									t.FullName,
									FlattenReflectionTypeLoadException(ex)),
								ex);
						}
					}
				}
				catch (Exception ex)
				{
					// ignore dynamic module error, no way to check for this condition first
					// http://groups.google.com/group/microsoft.public.dotnet.languages.csharp/browse_thread/thread/7b02223aefc6afba/c8f5bd05cc8b24b0
					if (!(ex is NotSupportedException && ex.Message.Contains("not supported in a dynamic")))
					{
						Log.Debug(
							typeof(ReflectionUtil),
							String.Format(
								"Error searching for types assignable to type {0} searching assembly {1} from {2}{3}",
								assignable.FullName,
								asm.FullName,
								asm.CodeBase,
								FlattenReflectionTypeLoadException(ex)),
							ex);
					}
				}
			}
			return list.ToArray();
		}
