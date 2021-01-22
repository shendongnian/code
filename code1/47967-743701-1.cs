    try {
        // Do whatever causes the exception
    } catch (Exception ex) {
        Console.WriteLine(ex.ToString());  // Or Debug.Print, or whatever
        throw; // So exception propagation will continue
    }
