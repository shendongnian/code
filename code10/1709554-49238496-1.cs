     foreach (DataRow DR in MainData.DataTable.Rows)
     {   
             //Rows containing a symbol mark score
             if ((DR["CN"].ToString() == "LC") && (DR["AW2"].ToString() != ""))
             {
                //Check to see if your dictionary contains the key, if not, add it
                if(!sGC.ContainsKey(DR["CSN"].ToString() + DR["AW2"].ToString()))
                {
                     sGC.Add(DR["CSN"].ToString() + DR["AW2"].ToString(), new 
                     Tuple<List<string>,List<string>>(new List<string>(), new 
                     List<string>()));
                }
            
                //Now that the key exists, if it didn't previously
                //If male add to list 1, else list 2 (for female)
                if(DR["PG"].ToString() == "Male")
                {
                     sGC[DR["CSN"].ToString() + DR["AW2"].ToString()].Item1.Add(DR["PupilID"].ToString());
                }
                else
                {
                     sGC[DR["CSN"].ToString() + DR["AW2"].ToString()].Item2.Add(DR["PupilID"].ToString());
                }
            }
        }
