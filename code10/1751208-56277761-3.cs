    public partial class Userrole
    {
        public string Rid { get; set; }//pk
        public string Uid { get; set; }//pk
        public virtual Role R { get; set; }//fk
        public virtual User U { get; set; }//fk
    }
