     List<string> selecttedColsList = dataExchangeSelectedColum.Split(',').ToList();
            string formattedColumns = "";
            //string comma = "";
            for (int i = 0; i < selecttedColsList.Count; i++)
            {
                //formattedColumns = string.Join(",", selecttedColsList.Select(col => $"[" + selecttedColsList[i] + "]"));
                formattedColumns+= ""+$"[" + selecttedColsList[i] + "]";
                if (i != selecttedColsList.Count - 1)
                {
                    formattedColumns += ",";
                }
               
            }            
