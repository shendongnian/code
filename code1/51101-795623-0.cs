    public class PClass
    {
        private static List<PClass> m_instances;
        public static IList<PClass> Instances
        {
            get
            {
                if (m_instances == null)
                    m_instances = LoadInstanceList();
                return m_instances;
            }
        }
        private static List<PClass> LoadInstanceList()
        {
            foreach (var assembly in AppDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsAssignableTo(typeof(PClass)) && type != typeof(PClass))
                        m_instances.Add(Activator.CreateInstance(type));
                }
            }
        }
    }
