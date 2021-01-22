    public struct SomeStruct {
      private SomeRefType m_MyRefVariableBackingField;
      public SomeRefType MyRefVariable {
        get { return m_MyRefVariableBackingField ?? (m_MyRefVariableBackingField = new SomeRefType()); }
      }
    }
