            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            private static bool isResolving;
            static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                if (!isResolving)
                {
                    isResolving = true;
                    var a = Assembly.LoadWithPartialName(args.Name);
                    isResolving = false;
                    return a;
                }
                return null;
            }
