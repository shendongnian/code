    private static List<List<string>> GetTestSentences()
    {
        return new List<List<string>>
        {
            // Prefix-only test
            new List<string>
            {
                "I went to The Home Depot",
                "I went to Walgreens",
                "I went to Best Buy",
            },
            // Suffix-only test
            new List<string>
            {
                "Game of Thrones is a good TV series",
                "Breaking Bad is a good TV series",
                "The Office is a good TV series",
            },
            // Prefix / Suffix test
            new List<string>
            {
                "The basketball team Los Angeles Lakers are my favorite",
                "The basketball team New York Knicks are my favorite",
                "The basketball team Chicago Bulls are my favorite",
            },
            // No prefix or suffix - all sentences are different
            new List<string>
            {
                "I went to The Home Depot",
                "Game of Thrones is a good TV series",
                "The basketball team Los Angeles Lakers are my favorite",
            },
            // All sentences are the same - no "topic" between prefix and suffix
            new List<string>()
            {
                "These sentences are all the same",
                "These sentences are all the same",
                "These sentences are all the same",
            },
            // Some sentences have no content between prefix and suffix
            new List<string>()
            {
                "This sentence has no topic",
                "This sentence [topic here] has no topic",
                "This sentence has no topic",
                "This sentence [another one] has no topic",
            },
            // First two topics have common beginnings
            new List<string>()
            {
                "The book named Lord of the Rings is a classic",
                "The book named Lord of the Flies is a classic",
                "The book named This is pretty is a classic",
                "The book named War and Peace is a classic",
                "The book named The Three Musketeers is a classic",
            },
            // The first two topics have a common ending
            new List<string>
            {
                "The movie named Matrix 2 is very good",
                "The movie named Avatar 2 is very good",
                "The movie named The Sound of Music is very good",
                "The movie named Terminator 2 is very good",
            }
        };
    }
