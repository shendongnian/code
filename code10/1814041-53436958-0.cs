    class StudentEqualityComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
            => (x.ElectiveOne == y.ElectiveOne &&
                x.ElectiveTwo == y.ElectiveTwo) ||
               (x.ElectiveOne == y.ElectiveTwo &&
                x.ElectiveTwo == y.ElectiveOne);
        public int GetHashCode(Student obj)
            => obj.ElectiveOne.GetHashCode() ^
               obj.ElectiveTwo.GetHashCode();
    }
