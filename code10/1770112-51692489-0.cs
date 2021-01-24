    public abstract class SavedInputsBase
    {
        public virtual string Name { get; set; }
        public virtual int Unique1 { get; set; }
        public virtual int Unique2 { get; set; }
    }
    
    public class ViewModel1 : SavedInputsBase
    {
        public override string Name { get; set; }
        public override int Unique1 { get; set; }
        ...
    }
    
    public class ViewModel2 : SavedInputsBase
    {
        public override string Name { get; set; }
        public override int Unique2 { get; set; }
        ...
    }
    public bool SaveToDb(SavedInputsBase model)
    {
        var inputs = new SavedInputs()
        {
            Name = model.Name,
            Unique1 = model.Unique1,
            Unique2 = model.Unique2
        }
    
        _db.SavedInputs.Add(inputs);
    }
