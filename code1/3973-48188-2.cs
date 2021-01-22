        private class QuestionSorter : IComparable<QuestionSorter>
        {
            public double SortingKey
            {
                get;
                set;
            }
            public Question QuestionObject
            {
                get;
                set;
            }
            public QuestionSorter(Question q)
            {
                this.SortingKey = RandomNumberGenerator.RandomDouble;
                this.QuestionObject = q;
            }
            public int CompareTo(QuestionSorter other)
            {
                if (this.SortingKey < other.SortingKey)
                {
                    return -1;
                }
                else if (this.SortingKey > other.SortingKey)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
