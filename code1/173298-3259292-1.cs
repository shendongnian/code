    class Contact
        {
            public string _Name;
            public string _Jid;
            public string _Group;
            public Contact()
            {
                _Name = "Test";
                _Jid = "One";
                _Group = "Two";
            }
            public Contact(string Name, string Jid, string Group)
            {
                _Name = Name;
                _Jid = Jid;
                _Group = Group;
            }
            public override string ToString()
            {
                return _Name+" "+_Jid+" "+_Group;
            }
        
        }
