    class Wall {
        public decimal Width {
           get {
               ...
           }
           set {
               ValidateChanges();
               width = value;
               CreateBays();
           }
        }
    
        public Bays[] Bays {
           get {
               ...
           }
           set {
               ValidateChanges();
               ...
           }
        }
    
        private void CreateBays() {
            // Delete all the old bays.
            ...
            // Create a new bay per spacing interval given the wall width.
            ...
        }
    }
