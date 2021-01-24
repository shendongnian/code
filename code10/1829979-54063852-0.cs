            private class ProjectDetail
        {
            public int Id {get;set;}
            public string Name {get;set;}
            DateTime StartDate {get;set;} = DateTime.Now;
            DateTime EndDate {get;set;} = DateTime.Now;
            public string Status {get;set;}
            public string toString => $"{Id} - {Name} - {StartDate} - {EndDate} - {Status}";
        }
