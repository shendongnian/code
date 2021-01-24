        public DisposableObject GetObject() {
            return new DisposableObject();
        }
        public void OtherMethod() {
            using (DisposableObject o = GetObject()) {
                try {
                    o.Open();
                } catch (Exception ex) {
                    // Log(ex);
                } finally {
                    // If not called within the dispose function.
                    o.Close();
                }
            }
        }
