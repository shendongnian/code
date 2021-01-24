    interface IShape
    {
        bool Intersect(IShape shape);
    }
    class Circle : IShape
    {
        public bool Intersect(IShape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    // Circle / circle intersection
                    break;
                case Rectangle rectangle:
                    // Circle / rectangle intersection
                    break;
                ....
                default:
                    throw new NotImplementedException();
            }
        }
    }
