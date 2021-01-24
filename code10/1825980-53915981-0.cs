    public static class HotelUtilities
    {
        public interface ITempVisitor
        {
        }
     
        private class HiddenTempVisitor : ITempVisitor
        {
           internal Guid UserId;
        }
        public static List<ITempVisitor> GetTempVisitors()
        {
            return new List<ITempVisitor>() { new HiddenTempVisitor { UserId = Guid.NewGuid } };
        }
        public static void UseTempVisitors(List<ITempVisitor> visitors)
        {
            foreach (HiddenTempVisitor visitor in visitors)
            {
                Console.WriteLine(visitor.UserId);
            }
        }
    }
