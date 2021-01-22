      public abstract class ClassB
      {
        class HasData : IHasData
        {
          HasData(ClassB b) {m_b = b;}
          Data IHasData.GetData() { m_b.GetData(); }
        }
        private readonly HasData m_hasData;
        public ClassB() {
          m_hasData = new HasData(this);
        }
        internal Data GetData() { 
          /** do something internal **/ 
        }
      }
