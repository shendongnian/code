    public class Reservation
    {
        public int BranchId { get; set; }
        // Other properties...
        public SelectList BranchOptions
        {
            get
            {
                return new SelectList(db.Branches);
            }
        }
        
        public Reservation(int branchId)
        {
            this.BranchId = branchId;
        }
    }
