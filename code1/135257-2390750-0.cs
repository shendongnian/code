         List<string> tablesNamesToRemove = new List<string>();
         foreach (string ikey in gridNum.Keys)
         {
            Hashtable aux = (Hashtable)gridNum[ikey];
            if (aux["OK"].ToString().Trim() == "1")
               tablesNamesToRemove.Add(ikey);
         }
 
         foreach (string name in tablesNamesToRemove)
         {
            gridNum.Remove(name);
         }
