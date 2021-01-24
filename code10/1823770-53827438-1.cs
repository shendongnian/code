    List<string> strList = new List<string>();
            List<int> intList = new List<int>();
            strList.Add("1");
            strList.Add("2");
            strList.Add("3");
            foreach(string el in strList)
            {
                intList.Add(Convert.ToInt32(el));
            }
