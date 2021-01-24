     public class Card 
     {
        public int CardId { get; set; }
        public string CardTitle { get; set; }
    
        public virtual ICollection<CardLayout> CardLayouts { get; set; }
        [NotMapped]
        public IEnumerable<Layout> Layouts
        {
           get
           {
             return this.CardLayouts.Select(cl => cl.Layout);
           }
        }
     }
