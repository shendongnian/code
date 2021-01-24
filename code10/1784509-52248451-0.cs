    try {
        Animal animal = GetAnimal();
    }catch(ValidationException ex)
    {}
    public class Animal
    {
       [Required]
       [StringLength(20)]
       public string Name { get; set; }
       public double Weight { get; set; }
       public double Height { get; set; }
       [Required, RangeAttribute(0, 9)]
       public int AnimalID { get; set; }
    }
    
