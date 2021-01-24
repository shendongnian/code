    public class MathFactory
    {
        public IOperations GetOperatorByType(string type)
        {
            switch (type)
            {
                case "Add":
                    return new Add(new Input());
                case "Multiply":
                    return new Multiply(new Input());
            }
    
            throw new Exception("Unknown type.");
        }
    }
