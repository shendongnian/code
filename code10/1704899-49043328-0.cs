    public string GetAllStrings()
        {
            string aFullString = "";
            int cnt = 0;
            while (cnt < aClass.Count)
            {             //+ to keep the previous values too
                aFullString += aClass[cnt].something;
                cnt++;
            }
            return aFullString;
        }
