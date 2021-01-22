    public int Add(params int[] numbers) {
        int result = 0;
        foreach (int i in numbers) {
            result += i;
        }
        return result;
    }
    // to call:
    int result = Add(1, 2, 3, 4);
    // you can also use an array directly
    int result = Add(new int[] { 1, 2, 3, 4});
