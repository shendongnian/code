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
