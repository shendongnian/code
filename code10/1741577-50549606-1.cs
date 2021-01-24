        void SaveDict(Dictionary<string, int> dateNumerDict)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream dataStream = new FileStream("Data.dat", FileMode.Create))
                {
                    binaryFormatter.Serialize(dataStream, dateNumerDict);
                }
            }
            catch (Exception ex) { /*log exception if you want*/ }
        }
