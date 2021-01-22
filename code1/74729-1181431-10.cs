        /// <summary>
        /// For all the assmeblies in the current application domain,
        /// Get me the object of all the Types that implement IMySortingAlgorithms
        /// </summary>
       static MyAlgoFactory()
            {
                m_dict = new Dictionary<string, IMySortingAlgorithms>();
                var type = typeof(IMySortingAlgorithms);
                foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type p in asm.GetTypes())
                    {
                        if (type.IsAssignableFrom(p) && p != type)
                        {
                            IMySortingAlgorithms algo = Activator.CreateInstance(p)
                                  as IMySortingAlgorithms;
                            m_dict[algo.Name] = algo;
                        }
                    }
                }
            }
