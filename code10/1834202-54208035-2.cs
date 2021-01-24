    private void button1_Click(object sender, EventArgs e)//Submit Button
    {
        if (isDone)
        {
            // Create a list of results from our file
            List<Result> existingResults = File.ReadAllLines(Path).Select(Result.Parse).ToList();
            // Add a new result to the list from the form data
            existingResults.Add(GetResultFromFormData());
            // Sort the list on the Score property
            existingResults = existingResults.OrderBy(result => result.Score).ToList();
            // Write the sorted list back to the file
            File.WriteAllLines(Path, existingResults.Select(result => result.ToString()));
        }
    }
