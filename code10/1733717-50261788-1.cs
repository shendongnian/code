    public partial class MainWindow : Window
    {
        public Dictionary<int, List<int>> gridDictionary = new Dictionary<int, List<int>>();
        private bool numberValide(int number, int gridIndex)  // Grid {1..5}
        {
            //Checks if dictionary has an entry at gridIndex
            if(gridDictionary.ContainsKey(gridIndex))
            {
                if (!gridDictionary[gridIndex].Value.Contains(number))
                {
                    //Add number to list in dictionary
                    gridDictionary[gridIndex].Value.Add(number);  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //Adds a new entry to the dictionary with a list containing number
                gridDictionary.Add(gridIndex, new List<int>() { number });
                return true;
            }           
        }
