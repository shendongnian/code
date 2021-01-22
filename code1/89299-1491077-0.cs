    //Get the currentCell/s changed
            object missing = System.T 
            string currentCell = Target.get_Address(
            missing, missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1,  missing, missing);
    //Split the currentCell variable this aids the logic in getting cell letter and number
             char[] delimiter = new char[] {'$'};
             string[] CellSplit = currentCell.Split(delimiter);
    
     //try parse the value in position 1 if this is true then a whole sheet has been pasted and needs to be checked
            //usually will be false if 1 cell is changed or multiple by dragging
            Int32 int32Val;
            bool result;
            result = Int32.TryParse(CellSplit.GetValue(1).ToString).Replace":", ""),System.Globalization.NumberStyles.Integer, null, out int32Val);
      //check the length of the array as this will help in determining how the cells have been changed
            int numCellSplit = CellSplit.Length;
      //the result is false if a single cell was changed and the length is 3
            if (CellSplit.Length == 3 && result == false)
            {
              \\your code here
            }
      //the result is true if the whole sheet has been pasted
            if (CellSplit.Length == 3 && result == true)
            {
              \\your code here
            }
      //if the user dragged the data from one cell across others
            if (CellSplit.Length == 5 && result == false)
            {
                //create char arrays to get the Alphabetical letters to use to loop
                char[] FirstLetter = CellSplit.GetValue(1).ToString().ToCharArray();
                char[] SecondLetter = CellSplit.GetValue(3).ToString().ToCharArray();
                
                int Alphaletter = (char)FirstLetter.GetValue(0);
                int Betaletter = (char)SecondLetter.GetValue(0);
                //Alphabetical letters have an int value so they can be used to loop through the cells
                for (int CellCheck = Alphaletter; CellCheck <= Betaletter; CellCheck++)
                {
                    int LoopStart = int.Parse(CellSplit.GetValue(2).ToString().Replace(":", ""));
                    int LoopEnd = int.Parse(CellSplit.GetValue(4).ToString());
                    for (; LoopStart <= LoopEnd; LoopStart++)
                    {
                        //your code here                        
                    }   
                }
                 
            }
