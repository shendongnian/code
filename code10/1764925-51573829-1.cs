    public class Analysis : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual Process Process { get; set; }
    }
