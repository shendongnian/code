    //The method that will add the average to the text box. You need to provide the row index.
    //One common way to get the row index would be the SelectedIndex of your data grid
    private void GetAverage(int rowIndex)
    {
        //Get the row whose data you want to process
        StudentsDataSet.StudentsRow courseMarks = studentsDataSet.Students.Rows[rowIndex];
        //Initialize an array with the names of the source columns
        string[] courseColumnNames = { "Course1", "Course2", "Course3", "Course4", "Course5",
            "Course6", "Course7", "Course8", "Course9", "Course10" };
        //Declare and initialize the array for the marks
        int[] markValues = new int[courseColumnNames.Length];
        //Fill the array with data
        for (int index = 0; index < courseMarks.Length ; index++)
        {
            //Get the column name of the current course
            string columnName = courseColumnNames[index];
            //Copy the column value into the array
            markValues[index] = courseMarks[columnName];
        }
        //Calculate the sum
        int sum = 0;
        for (int index = 0; index < courseMarks.Length ; index++)
        {
            sum += courseMarks[index];
        }
        //Calculate the average from the sum
        //Note: Since it's an integer division there will be no decimals
        int average = sum / courseMarks.Length;
        //Display the data
        averageBox.Text = average.ToString();           
    }
