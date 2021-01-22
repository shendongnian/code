    public void PopulateStack{
        for (int Index = 0; Index <= 100; Index++) {
            DataAndTime NewDataAndTime = new DataAndTime();
            NewDataAndTime.Data = (string)Index + " AS A STRING";
            NewDataAndTime.TimeInMilliSeconds = 1000 - Index;
            aStack.Push(NewDataAndTime);
        }
     } 
