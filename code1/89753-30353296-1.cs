    // This is not recommended. Performance is too horrible.
    public override int GetHashCode(byte[] obj)
    {
        // Inspired by fletcher checksum. Not fletcher.
        if (obj == null) {
            throw new ArgumentNullException("obj");
        }
        int sum = 0;
        int sumOfSum = 0;
        foreach (var val in obj) {
            sum += val; // by default, addition is unchecked. does not throw OverflowException.
            sumOfSum += sum;
        }
        return sum ^ sumOfSum;
    }
