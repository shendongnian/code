    **List of Vaccination for a Pet**
    public class Pet{
        public int AnimalId {get; set;}
        public string AnimalName{get; set;}
        public AnimalType Type {get; set;}
        public bool IsNeutered {get; set;}        
        public List<Vaccination> VaccineList {get; set;}
