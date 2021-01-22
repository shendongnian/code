    public class Sending : INotifyChanged
    {
        private int id;
        private DateTime dateSent;
        public Sending(int id, DateTime dateSent)
        {
            this.Id = id;
            this.DateSent = dateSent;
        }
    
        public int Id { get; set; }
        public DateTime DateSent 
         {
           get
             {
                return this.dateSend;
             }
          set
             {
               this.dateSent = value;
               OnPropertyChangerd("DateSent");
               //CallYou List<Sending> Sort method;
             }
    }
