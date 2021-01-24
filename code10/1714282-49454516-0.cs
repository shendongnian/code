        class Answer
        {
            private List<int> _dependentQuestions;
            public List<int> DependentQuestions
            {
                get
                {
                    if (_dependentQuestions == null)
                        // load questions here
        
                    return _dependentQuestions;
                }
            }
        }
    Note that this assumes id is already set, you probably should validate that too.
