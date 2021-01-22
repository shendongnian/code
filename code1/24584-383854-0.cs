    public static Vector Add(Vector vector1, Vector vector2) {
        
        Vector returnVector = vector1.Clone()
        return returnVector.Add(vector2);
    }
    
    public Vector Add(Vector vector) {
        // check parameters for null, and compare Lengths
        for (int index = 0; index < Length; index++) {
            this[index] += vector[index];
        }
        return this;
    }
