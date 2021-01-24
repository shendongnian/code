    public class Muscle
    {
    [Key]
    public int MuscleId { get; set; }
    public string nom { get; set; }
    public virtual ICollection<Exercice> Exercices { get; set; }
    }
