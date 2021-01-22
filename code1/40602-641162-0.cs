    class Test
    {
        string Predicate { get; set; }
        Action Verb { get; set; }
        Test(string predicate, Action verb)
        {
           Predicate = predicate;
           Verb = verb;
        }
        bool Execute(XmlElement e)
        {
            if (e.SelectSingleNode(Predicate) != null)
            {
                Verb();
                return true;
            }
            return false;
        }
    }
