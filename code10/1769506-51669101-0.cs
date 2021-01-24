    int amountOfRows;
    Label[] labels;
    public void setLabels(List<string> inputData)
    {
        //allocate memory for the array
        amountOfRows = inputData.Count;
        labels = new Label[amountOfRows];
        for(int i=0; i<amountOfRows; i++)
        {
            labels[i] = new Label();
            //set properties like location and size of labels here first
            labels[i].Text = inputData[i];
        }
    }
