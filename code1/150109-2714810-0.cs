    class Instance
    {
        public int start;
        public int length;
        public string text;
        public Instance(int _start, int _length, string _text)
        {
            start = _start;
            length = _length;
            text = _text;
        }
    };
    static void Main(string[] args)
    {
        string test = "Chairman Joe Smith has announced a new plan to decrease expenditures by outsourcing the planning of the new dining hall. Smith states the current project managers do not have excess time to commit to this new project and this will be less costly than hiring a new or contract project manager.";
        string[] lookup = { "Chairman Joe Smith", "Joe Smith", "Smith", "Chairman Smith" };
        List<Instance> li = new List<Instance>();
        // record each instance of specified strings
        foreach (string name in lookup)
        {
            int index = 0;
            do
            {
                index = test.IndexOf(name, index);
                if (index > -1)
                {
                    li.Add(new Instance(index, name.Length, name));
                    index += name.Length;
                }
            } while (index > -1);
        }
        // eliminate duplicate instances
        Retry:
        foreach (Instance i in li)
        {
            foreach (Instance j in li)
            {
                if (j != i)
                {
                    if ((j.start >= i.start) && (j.start + j.length <= i.start + i.length))
                    {
                        li.Remove(j);
                        goto Retry;
                    }
                }
            }
        }
        // replace each instance with respective text
        foreach (Instance i in li)
        {
            test = test.Remove(i.start, i.length);
            string final = "<a href='smithbio.html'>" + i.text + "</a>";
            test = test.Insert(i.start, final);
            foreach (Instance j in li)
            {
                j.start += (final.Length - i.length);
            }
        }
        Console.WriteLine(test);
        Console.ReadLine();
    }
