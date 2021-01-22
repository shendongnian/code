        static bool EnumTest(int testVal, Enum e)
        {
            bool result = false;
            foreach (var val in Enum.GetValues(typeof(Enum1)))
            {
                if ((int)val == testVal)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
