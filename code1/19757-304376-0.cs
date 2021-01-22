        static public IEnumerable<IVsProject> LoadedProjects
        {
            get
            {
                IVsSolution solution = _serviceProvider.GetService(typeof(SVsSolution)) as IVsSolution;
                IEnumHierarchies enumerator = null;
                Guid guid = Guid.Empty;
                solution.GetProjectEnum((uint)__VSENUMPROJFLAGS.EPF_LOADEDINSOLUTION, ref guid, out enumerator);
                IVsHierarchy[] hierarchy = new IVsHierarchy[1] { null };
                uint fetched = 0;
                for (enumerator.Reset(); enumerator.Next(1, hierarchy, out fetched) == VSConstants.S_OK && fetched == 1; /*nothing*/)
                {
                    yield return (IVsProject)hierarchy[0];
                }
            }
        }
