    MethodInfo method = Type.GetType("Assembly.Namespace.ABC").GetConstructor(
                            BindingFlags.NonPublic | BindingFlags.Instance,
                            null,
                            new[] { typeof(string) },
                            null
                        );
    ABC o = (ABC)method.Invoke(new[] { "test" });
