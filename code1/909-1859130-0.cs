        public static List<long> GetIds<T>(this List<T> original){
            List<long> ret = new List<long>();
            if (original == null)
                return ret;
            try
            {
                foreach (T t in original)
                {
                    IIDable idable = (IIDable)t;
                    ret.Add(idable.getId());
                }
                return ret;
            }
            catch (Exception)
            {
                throw new Exception("Class calling this extension must implement IIDable interface");
            }
    
