    // equal if their Codes are equal
    public bool Equals(Department x, Department y) {
        // reference the same objects?
        if (Object.ReferenceEquals(x, y)) return true;
        // is either null?
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;
        return x.Code == y.Code;
    }
    public int GetHashCode(Department dept) {
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        // if null default to 0
        if (Object.ReferenceEquals(dept, null)) return 0;
        return dept.Code.GetHashCode();
    }
}
    IEnumerable<Department> deptExcept = departments.Except(departments2, 
        new DepartmentComparer());
    
    foreach (Department dept in deptExcept) {
        Console.WriteLine("{0} {1}", dept.Code, dept.Name);
    }
    // departments not in departments2: AC, Accounts.
