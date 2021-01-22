    public class Sample
    {
        public int PropertyA {get;set;}
        public bool PropertyB {get;set;}
        public string PropertyC {get;set;}
        public double PropertyD {get;set;}
    }
    
    List<Sample> samples = new List<Samples>(GetSamples());
    var sampleBinding = from sample in samples
                        select new
                        {
                            PropertyA = sample.PropertyA,
                            PropertyC = sample.PropertyC
                        };
    
    BindingList bl = new BindingList();
    bl.DataSource = sampleBinding;
    dgv.DataSource = bl;
