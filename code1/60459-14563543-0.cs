    public static class Extensions
    {
        public static Questions Get(this Questions qs, Question q)
        {
            return qs.Get((int)q);
        }
    }
