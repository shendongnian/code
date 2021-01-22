            public bool test()
        {
            try
            {
                object oVal;
                bool b = Parsing.TryParse(typeof(int), "123", out oVal);
                if (!b) return false;
                int x = (int)oVal;
                if (x!= 123) return false;
            }
            catch (System.Exception)
            {
                return false;
            }
            try
            {
                int x;
                bool b = Parsing.TryParseGeneric<int>("123", out x);
                if (!b) return false;
                if (x != 123) return false;
            }
            catch (System.Exception)
            {
                return false;
            }
            try
            {
                object oVal;
                bool b = Parsing.TryParse(typeof(string), "123", out oVal);
                //should throw an exception (//no method String.TryParse(string s, out string val)
                return false;
            }
            catch (System.Exception)
            {
                //should throw an exception
            }
            return true;
        }
    }
