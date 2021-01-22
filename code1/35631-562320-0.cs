    using System;
    using System.Collections.Generic;
    using System.Threading;
    namespace Something
    {
        class ProcessFilesClass
        {
            private object m_Lock = new object();
            private Dictionary<string, object> m_WorkingItems = 
                new Dictionary<string, object>();
            private Timer m_Timer;
            public ProcessFilesClass()
            {
                m_Timer = new Timer(OnElapsed, null, 0, 10000);
            }
            public void OnElapsed(object context)
            {
                List<string> xmlList = new List<string>();
                //Process xml files into xmlList
                foreach (string xmlFile in xmlList)
                {
                    lock (m_Lock)
                    {
                        if (!m_WorkingItems.ContainsKey(xmlFile))
                        {
                            m_WorkingItems.Add(xmlFile, null);
                            ThreadPool.QueueUserWorkItem(DoWork, xmlFile);
                        }
                    }
                }
            }
            public void DoWork(object xmlFile)
            {
                //process xmlFile
                lock (m_Lock)
                {
                    m_WorkingItems.Remove(xmlFile.ToString());
                }
            }
        }
    }
