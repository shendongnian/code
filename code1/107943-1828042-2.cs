    public class Coffee
    {
        public List<ExpressoExpressionBuilder> expressoExpressions { get; private set; }
        public bool HasCream { get; private set; }
        public int CupSizeInOunces { get; private set; }
        public static Coffee Make
        {
            get
            {
                var coffee = new Coffee
                                 {
                                     expressoExpressions = new List<ExpressoExpressionBuilder>()
                                 };
                return coffee;
            }
        }
        public Coffee WithCream()
        {
            HasCream = true;
            return this;
        }
        public Coffee ACupSizeInOunces(int ounces)
        {
            CupSizeInOunces = ounces;
            return this;
        }
        public Coffee PourIn(Action<ExpressoExpressionBuilder> action)
        {
            var expression = new ExpressoExpressionBuilder();
            action.Invoke(expression);
            expressoExpressions.Add(expression);
            return this;
        }
        
        }
    public class ExpressoExpressionBuilder
    {
        public readonly Queue<ExpressoExpression> ExpressoShots = 
            new Queue<ExpressoExpression>();
        public ExpressoExpressionBuilder ShotOfExpresso()
        {
            var shot = new ExpressoExpression();
            ExpressoShots.Enqueue(shot);
            return this;
        }
        public ExpressoExpressionBuilder AtTemperature(int temp)
        {
            var recentlyAddedShot = ExpressoShots.Peek();
            recentlyAddedShot.Temperature = temp;
            return this;
        }
        public ExpressoExpressionBuilder OfPremiumType()
        {
            var recentlyAddedShot = ExpressoShots.Peek();
            recentlyAddedShot.IsOfPremiumType = true;
            return this;
        }
    }
    public class ExpressoExpression
    {
        public int Temperature { get; set; }
        public bool IsOfPremiumType { get; set; }
        public ExpressoExpression()
        {
            Temperature = 0;
            IsOfPremiumType = false;
        }
    }
