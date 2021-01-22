    static void Main(string[] args) {
        ArrayList list = new ArrayList();
        list.Add(1);
        list.Add("one");
        foreach (object obj in list) {
            if (obj is int) {
                Console.WriteLine((int)obj);
            } else {
                Console.WriteLine("not an int");
            }
        }
    }
