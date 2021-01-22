    public override bool Equals(object obj) {
        Student other = obj as Student;
        if(other == null) {
            return false;
        }
        return (this.Name == other.Name) && (this.ID == other.ID);
    }
    public override int GetHashCode() {
        return 33 * Name.GetHashCode() + ID.GetHashCode();
    }
