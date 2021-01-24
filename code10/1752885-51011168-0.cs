    public class Advert {
        public int ID { get; set; }
        public DateTime DateCreation { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public virtual Member Owner { get; set; }
    }
