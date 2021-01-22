    public abstract classFileBase
    {
        // include common features here
    }
    public class File1 : FileBase
    {
        public string Field_1 {get ; set}
        public string Field_2 {get ; set}
        .
        .
        .
        public string Field_10 {get ; set}
    }
    
    public Dictionary<string, FileBase>ReadFile(string file)
    {
        //Open and Parse File and read into class specified by typ
    }
