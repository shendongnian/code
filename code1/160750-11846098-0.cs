        public static int[] ConvertArray(string[] arrayToConvert)
        {
            int[] resultingArray = new int[arrayToConvert.Length];
            int itemValue;
            resultingArray = Array.ConvertAll<string, int>
                (
                    arrayToConvert, 
                    delegate(string intParameter) 
                    {
                        int.TryParse(intParameter, out itemValue);
                        return itemValue;
                    }
                );
            return resultingArray;
        }
