        Dictionary<string, int> LoadDict()
        {
            Dictionary<string, int> dateNumDict = new Dictionary<string, int>();
            if(File.Exists("Data.dat"))
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream("Data.dat", FileMode.Open))
                    {
                        dateNumDict = (Dictionary<string, int>)binaryFormatter.Deserialize(fileStream) ;
                    }
                }
                catch (Exception ex) { /*log exception if you want*/ }
            }
            return dateNumDict;
        }
