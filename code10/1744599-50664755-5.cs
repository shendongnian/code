    class FloatToStringProcessor : IProcessor<float, string>
    {
        public string Process(float input, Context context)
        {
            return input.ToString();
        }
    }
    class RepeatStringProcessor : IProcessor<string, string>
    {
        public string Process(string input, Context context)
        {
            return input + input + input;
        }
    }
    class Program
    {
        public static void Main()
        {
            var pipeline = Pipeline
                .Create(new FloatToStringProcessor())
                .AppendProcessor(new RepeatStringProcessor());
            Context ctx;
            var result = pipeline.Execute(5, out ctx);
            Console.WriteLine($"Pipeline result: {result}");
            Console.WriteLine($"Pipeline execution took {ctx.ProcessTimeInMilliseconds} milliseconds");
        }
    }
