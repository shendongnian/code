    int year = (int)jsonObject["year"];
    int quarter = (int)jsonObject["quarter"];
    // Find all the descendant JProperties in the JObject with names having 
    // a length of 32-- these represent the questions.
    var props = jsonObject.Descendants()
        .OfType<JProperty>()
        .Where(prop => prop.Name.Length == 32);
    // Transform the properties into a list of Rows
    List<Row> rows = new List<Row>();
    foreach (JProperty prop in props)
    {
        // Create a list of answers for the question
        var answers = new List<string>();
        // if the property value is a string, this is one of the nested questions
        // and the "answer" is actually an ID
        if (prop.Value.Type == JTokenType.String)
        {
            answers.Add((string)prop.Value);
        }
        // if the property value is an object, we could have 0, 1 or many answers inside
        else if (prop.Value.Type == JTokenType.Object)
        {
            if (prop.Value["answer"] != null)  // single answer
            {
                answers.Add((string)prop.Value["answer"]);
            }
            else if (prop.Value["selectedAnswers"] != null)  // many answers
            {
                answers.AddRange(prop.Value["selectedAnswers"].Values<string>());
            }
            else  // no answers
            {
                answers.Add(null);
            }
        }
        // Now create a Row for each answer for this question and add it to the list of rows
        foreach (string answer in answers)
        {
            rows.Add(new Row
            {
                Year = year,
                Quarter = quarter,
                Question = prop.Name,  // The property name is the question ID
                Answer = answer
            });
        }
    }
