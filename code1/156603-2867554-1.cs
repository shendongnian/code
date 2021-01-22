    public static void blah(A anAObject) {
        var aBObject = anAObject as B;
        if (aBObject != null)
            Console.WriteLine(aBObject.fe); // would print "B"
        else
            Console.WriteLine(anAObject.fe); // would print "A"
    }
    
