     bool IsRuleSatisfied(XmlElement rule)
     {
        bool satisfied = true;
        foreach (XmlElement child in rule.SelectNodes("*"))
        {
           if (child.Name == "question")
           {
              satisfied = satisfied && IsQuestionCorrect(child);
           }
           if (child.Name == "choice")
           {
              satisfed = satisfied && IsChoiceCorrect(child);
           }
           if (!satisfied)
           {
              return false;
           }
       }
       return true;
    }
