    public IList<Question> ParseXml(string xmlString)
    {
        var result = new List<Question>();
        var xml = XElement.Parse(xmlString);
        var questionNodes = xml.Elements("question");
        //If there were no question nodes, return an empty collection
        if (questionNodes == null)
            return result;
        foreach (var questionNode in questionNodes)
        {
            var idNode = questionNode.Element("ID");
            var textNode = questionNode.Element("questiontext");
            var ant1Node = questionNode.Element("antwort1");
            var ant2Node = questionNode.Element("antwort2");
            var ant3Node = questionNode.Element("antwort3");
            var ant4Node = questionNode.Element("antwort4");
            var question = new Question();
            question.Id = Convert.ToInt32(idNode?.Value);
            // note the '?.' syntax. This is a dirty way of avoiding NULL
            // checks. If textNode is null, it returns null, otherwise it
            // returns the textNode.Value property
            question.Text = textNode?.Value;
            question.AnswerOne = ant1Node?.Value;
            question.AnswerTwo = ant2Node?.Value;
            question.AnswerThree = ant3Node?.Value;
            question.AnswerFour = ant4Node?.Value;
            result.Add(question);
        }
        return result;
    }
