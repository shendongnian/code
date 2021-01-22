    Public Delegate Sub MyEventDelegate()
    <NonSerialized()>Private m_MyEventDelegate As MyEventDelegate
    Public Custom Event MyEvent As MyEventDelegate
        AddHandler(ByVal value As MyEventDelegate)
            m_MyEventDelegate = DirectCast(System.Delegate.Combine(m_MyEventDelegate, value), MyEventDelegate)
        End AddHandler
        RemoveHandler(ByVal value As MyEventDelegate)
            m_MyEventDelegate = DirectCast(System.Delegate.Remove(m_MyEventDelegate, value), MyEventDelegate)
        End RemoveHandler
        RaiseEvent()
            If m_MyEventDelegate IsNot Nothing Then
                m_MyEventDelegate.Invoke()
            End If
        End RaiseEvent
    End Event
