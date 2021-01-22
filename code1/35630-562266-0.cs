    class XmlManager {
      private object m_lock = new object();
      private HashSet<string> m_inPool = new HashSet<string>();
    
      private void Run(object state) {
        string name = (string)state;
        try { 
          FunctionThatActuallyProcessesFiles(name);
        } finally { 
          lock ( m_lock ) { m_inPool.Remove(name); }
        }
      }
    
      public void MaybeRun(string xmlName) { 
        lock ( m_lock ) { 
          if (!m_pool.Add(xmlName)) {
            return;
          }
        }
        ThreadPool.QueueUserWorkItem(Run, xmlName);
      }
    }
