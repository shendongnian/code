     public sealed class ModelOutput
            {
                public TensorString ClassLabel = TensorString.Create(new long[] { 1, 1 });
                public IList<IDictionary<string, float>> Loss = new List<IDictionary<string, float>>();
            }
