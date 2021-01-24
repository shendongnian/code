    class Profession
    {
        ...
        public override string ToString()
        {
            return string.Format("{{Id: {0}, Description: {1}}}", Id, Description);
        }
    }
