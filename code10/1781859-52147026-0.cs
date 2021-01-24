    private object[] m_SelectedObjects = new object[0];
    public object[] SelectedObjects {
      get {
        return m_SelectedObjects;
      }
    }
    private void MyRemove() {
      // We can't modify read-only property but can operate with its backing field 
      m_SelectedObjects = m_SelectedObjects.OfType<ClassB>().ToArray();
    }
