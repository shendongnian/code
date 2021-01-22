    public void StartStatusMonitoring()
    {
      if (!Active)
      {
        // Create a point-to-point message queue to get the notifications.
        m_p2pmq = new P2PMessageQueue(true);
        m_p2pmq.DataOnQueueChanged += new EventHandler(p2pmq_DataOnQueueChanged);
        // Ask the system to notify our message queue when devices of
        // the indicated class are added or removed.
        m_requestHandle = RequestDeviceNotifications(m_deviceClass.ToByteArray(),
                          m_p2pmq.Handle, m_fAll);
      }
    }
