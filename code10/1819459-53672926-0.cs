    public interface IHtmlElement {
        string ToHtmlString();
    }
    public class LocalityGeneratorForm : IHtmlElement
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Description of the field")]
        public Locality[] locality { get; set; }
        public virtual ICollection<Locality> Localities { get; }
        public string ToHtmlString()
        {
            // convert Locality to html string representation
            return "<p>HTML element string for Locality</p>"
        }
    }
    
    public class GoalGeneratorForm : IHtmlElement
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "A different description of the field")]
        public Goal[] goal { get; set; }
        public virtual ICollection<Goal> Goals { get; }
        public string ToHtmlString()
        {
            // convert Goal to html string representation
            return "<p>HTML element string for Goal</p>"
        }
    }
