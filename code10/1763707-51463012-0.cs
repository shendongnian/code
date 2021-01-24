    class Champion {
        public string Name { get; set; }
        public Champion([CallerMemberName] string name = "") {
            Name = name;
        }
    }
