        /// <summary>
        /// Manufacturer Data Transfer Object
        /// </summary>
        public class MfgBO {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Active { get; set; }
        }
      }
    public class TypeBO {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Active { get; set; }
        }
     public class ModelBO {
            #region Private Variables
            
            private int mmtId = -1;
            private int id = -1;
            private string name = String.Empty;
            private bool active = false;
            private MfgBO mfg = new MfgBO();
            private TypeBO type = new TypeBO();
    
            #endregion
            // Getter and setters below
