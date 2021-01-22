	//Constructor
	static MyClass()
        {
            //Provoque l'événement quand .Net ne sait pas retrouver un Assembly référencé
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        /// <summary>
        /// Mémorise les assembly référencés par d'autres qui ne sont pas dans le répertoire principal d'EDV
        /// </summary>
        static Dictionary<string, string> _AssembliesPath;
        /// <summary>
        /// .Net ne sait pas retrouver un Assembly référencé
        /// Cherche et charge d'après les assembly référencés par d'autres qui ne sont pas dans le répertoire principal d'EDV        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (_AssembliesPath != null && _AssembliesPath.ContainsKey(args.Name))
            {
                Assembly lAssembly = Assembly.LoadFile(_AssembliesPath[args.Name]);
                AddAssemblyReferencedAssemblies(lAssembly, System.IO.Path.GetDirectoryName(lAssembly.Location));
                return lAssembly;
            }
            Error = string.Format("L'assembly {0} n'a pu être chargé", args.Name);
            return null;
        }
        /// <summary>
        /// Mémorise les assembly référencés par d'autres qui ne sont pas dans le répertoire principal d'EDV        
        /// </summary>
        /// <param name="pAssembly"></param>
        /// <param name="psRootPath"></param>
        static void AddAssemblyReferencedAssemblies(Assembly pAssembly, string psRootPath)
        {
            if (_AssembliesPath == null) _AssembliesPath = new Dictionary<string, string>();
            foreach (AssemblyName lRefedAss in pAssembly.GetReferencedAssemblies())
                if (!_AssembliesPath.ContainsKey(lRefedAss.FullName))
                {
                    string lsRoot = psRootPath + "\\" + lRefedAss.Name + ".";
                    string lsExt;
                    if (System.IO.File.Exists(lsRoot + (lsExt = "dll")) || System.IO.File.Exists(lsRoot + (lsExt = "exe")))
                    {
                        _AssembliesPath.Add(lRefedAss.FullName, lsRoot + lsExt);
                    }
                }
        }
