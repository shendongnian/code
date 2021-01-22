                     public bool GetIsExistSubstring(string mainstring, string substring)
        {        
            bool Isexist=false;
            int i = -1;
            mainstring = string.Format(",{0},", mainstring);//so it will be like  ,1,2,3,
            substring = string.Format(",{0},", substring);//so it will be like  ,1,
            i=mainstring.IndexOf(substring);
            if(i!=-1)
            {
                Isexist = true;
            }
            return Isexist;
        }
