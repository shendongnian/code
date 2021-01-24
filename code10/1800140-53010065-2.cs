    public class IrisData
    {
        public float Label;
        public float SepalLength;
        public float SepalWidth;
        public float PetalLength;
        public float PetalWidth;
    }
    
    public class IrisVectorData
    {
        public float Label;
        public float[] Features;
    }
    
    static void Main(string[] args)
    {
        // Here's a data array that we want to work on.
        var dataArray = new[] {
            new IrisData{Label=1, PetalLength=1, SepalLength=1, PetalWidth=1, SepalWidth=1},
            new IrisData{Label=0, PetalLength=2, SepalLength=2, PetalWidth=2, SepalWidth=2}
        };
    
        // Create the ML.NET environment.
        var env = new Microsoft.ML.Runtime.Data.TlcEnvironment();
    
        // Create the data view.
        // This method will use the definition of IrisData to understand what columns there are in the 
        // data view.
        var dv = env.CreateDataView<IrisData>(dataArray);
    
        // Now let's do something to the data view. For example, concatenate all four non-label columns
        // into 'Features' column.
        dv = new Microsoft.ML.Runtime.Data.ConcatTransform(env, dv, "Features", 
            "SepalLength", "SepalWidth", "PetalLength", "PetalWidth");
    
        // Read the data into an another array, this time we read the 'Features' and 'Label' columns
        // of the data, and ignore the rest.
        // This method will use the definition of IrisVectorData to understand which columns and of which types
        // are expected to be present in the input data.
        var arr = dv.AsEnumerable<IrisVectorData>(env, reuseRowObject: false)
            .ToArray();
    }
