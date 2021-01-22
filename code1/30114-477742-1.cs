        public class TestThis
    {
        public bool test()
        {
            try
            {
                int x;
                bool b = Parsing.TryParse<int>("123", out x);
                if (!b) return false;
                if (x != 123) return false;
            }
            catch (System.Exception)
            {
                return false;
            }
            try
            {
                string x;
                bool b = Parsing.TryParse<string>("123", out x);
                //should throw an exception (//no method String.TryParse(string s, out string val)
                return false;
            }
            catch (System.Exception)
            {
                //should throw an exception (//no method String.TryParse(string s, out string val)
            }
            return true;
        }
    }
