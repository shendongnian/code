    public class LoadTestPluginExample : ILoadTestPlugin
    {
        private LoadTest m_loadTest;
        private int warmUpPlusRunDuration;
        public void Initialize(LoadTest loadTest)
        {
            m_loadTest = loadTest;
            warmUpPlusRunDuration = m_loadTest.RunSettings.WarmupTime + m_loadTest.RunSettings.RunDuration;
        }
        ... other plugin methods that use warmUpPlusRunDuration
    }
