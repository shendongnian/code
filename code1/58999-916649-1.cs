        public static bool operator == (Entity base1, Entity base2)
        {
            if (base1.Id != base2.Id)
            {
                return false;
            }
            return true;
        }
