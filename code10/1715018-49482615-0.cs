    class Student
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public int YearLevel { get; private set; }
        const int yearLevelMin = 9;
        const int yearLevelMax = 13;
        public Student(int number, string name, int yearlevel)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (yearlevel < yearLevelMin || yearlevel > yearLevelMax)
                throw new StudentException($"{nameof(yearlevel)} must be between {yearLevelMin} and {yearLevelMax}.");
            Number = number;
            Name = name;
            YearLevel = yearlevel;
        }
    }
