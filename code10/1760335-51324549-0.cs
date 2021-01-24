            List<string> lsOut = new List<string>() { };
            string sInput = "AB-PQ-EF=CD-IJ=XY-JK";
            string sTemp = "";
            for (int i = 0; i < sInput.Length; i++)
            {
                if ( (i + 1) % 6 == 0)
                {
                    continue;
                }
                // add to temp
                sTemp += sInput[i];
                // multiple of 5, add all the temp to list
                if ( (i + 1 - lsOut.Count) % 5 == 0)
                {
                    lsOut.Add(sTemp);
                    sTemp = "";
                }
                if(sInput.Length == i + 1)
                {
                    lsOut.Add(sTemp);
                }
            }
            
