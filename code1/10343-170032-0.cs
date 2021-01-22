	<Extension()> Public Function ReadSection(ByVal lock As ReaderWriterLockSlim) As ReadWrapper
		Return New ReadWrapper(lock)
	End Function
	Public NotInheritable Class ReadWrapper
		Implements IDisposable
		Private m_Lock As ReaderWriterLockSlim
		Public Sub New(ByVal lock As ReaderWriterLockSlim)
			m_Lock = lock
			m_Lock.EnterReadLock()
		End Sub
		Public Sub Dispose() Implements IDisposable.Dispose
			m_Lock.ExitReadLock()
		End Sub
	End Class
