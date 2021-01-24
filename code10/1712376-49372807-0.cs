    public IEnumerator ScrambleCube () {
        ScrambleR.ScrambleRNotation();
        yield return new WaitForSeconds(1); // This pauses the execution of 
                                            // the function for 1 second
        ScrambleU.ScrambleUNotation();
        // etc...
    }
