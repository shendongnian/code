    partial class CartoonStory
    {
        public IEnumerable<CartoonFigure> FemalesThenMales
        {
            get
            {
                return Females.Count() > 0 ? Females : Males;
            }
        }
        public IEnumerable<CartoonFigure> Females
        {
            get
            {
                return CartoonFigures.Where(c => c.Sex.Name == "Female");
            }
        }
        public IEnumerable<CartoonFigure> Males
        {
            get
            {
                return CartoonFigures.Where(c => c.Sex.Name == "Male");
            }
        }
    }
