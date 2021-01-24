        static bool IsSuperscript(string s)
        {
            foreach(var c in s)
            {
                if(!IsSuperscript(c))
                {
                    return false;
                }
            }
            return true;
        }
