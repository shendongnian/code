        //this function produce the cartesian product of two lists
        List<string> CartesianProduct(List<string> lst1, List<string> lst2, string seperator)
        {
            var res = new List<string>();
            for (int i = 0; i < lst1.Count; i++)
            {
                for (int j = 0; j < lst2.Count; j++)
                {
                    res.Add(lst1[i] + seperator + lst2[j]);
                }
            }
            return res;
        }
        //This function apply the cartesian product to all lists
        List<string> CartesianProduct(List<List<string>> lsts, string seperator)
        {
            List<string> res = lsts[0];
            for (int i = 1; i < lsts.Count; i++)
            {
                res = CartesianProduct(res, lsts[i], seperator);
            }
            return res;
        }
