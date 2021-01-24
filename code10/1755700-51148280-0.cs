    [Serializable]
    public class SampleModelClass
    {
        [Terms(@"^[.*]$")]
        public string FirstField { get; set; }
    
        [Terms(@"^[.*]$")]
        public string SecondField { get; set; }
    
        public static IForm<SampleModelClass> BuildForm()
        {
            return new FormBuilder<SampleModelClass>()
                    .Message(async (state) => { return new PromptAttribute($"Welcome to the form bot!"); })
                    .Build();
    
    
        }
    }
