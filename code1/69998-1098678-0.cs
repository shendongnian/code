    public class Test
    {
        public string GetDecision(Decision decision)
        {
            switch (decision)
            {
                case Decision.Yes:
                    return "Yes, that's my decision";
                case Decision.No:
                    return "No, that's my decision";
                default: throw new Exception(); // raise exception here.
            }
        }
    }
