    Config = JObject.FromObject(new
                                                {
                                                    questions = JArray.FromObject(
                                                    new List<Question>
                                                    {
                                                        new Question
                                                        {
                                                            Key = "contact",
                                                            Label = "Contact Person",
                                                            HelpText = "",
                                                            Config = emptyJObject,
                                                            Type = "text",
                                                            ContextTarget = "$.data.contact"
                                                        },
                                                        new Question
                                                        {
                                                            Key = "company",
                                                            Label = "Company Name",
                                                            HelpText = "",
                                                            Config = emptyJObject,
                                                            Type = "text",
                                                            ContextTarget = "$.data.company"
                                                        }
                                                    })
                                                })
