    public class Paper
    {
        public List<Genes> questionGenes { get; set; }
    
        // default constructor
        public Paper()
        {
             questionGenes = new List<Genes>();
        }
        // constructor that creates a paper from a List<Genes>
        public Paper(List<Genes> questionGene)
        {
             questionGenes = questionGene;
        }
    }
