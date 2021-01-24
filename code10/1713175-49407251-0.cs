    public class SpellsTemplate
    {
        public SpellsTemplate(int id)
        {
            this.Id = id;
        }
        // Make the setter for the ID property private, so it 
        // can only be set within this class (e.g. in the constructor).
        public int Id { get; private set; }
        // The rest of your properties go here.
    }
