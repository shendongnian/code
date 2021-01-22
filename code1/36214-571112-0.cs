    public class SaveArgs
    {
       public SaveArgs(TEntity value) { this.Value = value; }
       public TEntity Value { get; private set;}
       public int NewId { get; internal set; }
       public bool NewIdGenerated { get; internal set; } 
    }
