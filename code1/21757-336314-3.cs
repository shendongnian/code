                public virtual string GetSomeString(IDependance objectThatITalkTo)
                {
                    if (objectThatITalkTo.GiveMeAString() == "Hello World")
                        return "Hi";
                }
