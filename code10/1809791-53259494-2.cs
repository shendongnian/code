            for (int i = 0; i < recordCount; i++)
            {
                output += QuestionPropertyToJson(questionBank.Properties[i]);
                if (i != recordCount - 1)
                {
                    output += ",";
                }
            }
