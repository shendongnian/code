            StreamReader objReader = new StreamReader(filename);
            string sLine = "";
            ArrayList arrText = new ArrayList();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();
            arrText.Reverse();
            foreach (string sOutput in arrText)
            {
...
