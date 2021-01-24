        public DisposableObject GetObject() {
            var o = new DisposableObject();
            try {                
                o.Open();
                return o;
            } catch (Exception ex) {
                o.Dispose(); // o.Close is called within.
                throw ex;
            } 
        }
