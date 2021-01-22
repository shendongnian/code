    var serializer = new JsonSerializer
        					{
        						ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                ContractResolver = new DefaultContractResolver
                                    {
        								DefaultMembersSearchFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
                                    },
        						TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
        									
        						ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        					};
