    public class JSGridVM<JSTable>
    {
        public List<JSTable> Tables { get; set; };
    }
    
    public class JSTable<?>
    {
    
    }
    
    var rowTypeAnimals = AnimalRowType();
    var rowTypeBirds = BirdRowType();
    
    var animalTable = new JSTable<AnimalRowType>(){rowTypeAnimals };
    var birdTable = new JSTable<BirdRowType>(){rowTypeBirds };
    
    var grid = new JSGridVM(){animalTable,birdTable};
