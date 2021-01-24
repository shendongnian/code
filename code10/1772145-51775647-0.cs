    public class OldFashionedThread
    {
        private readonly List<string> _listOfStrings = new List<string>();
        public IEnumerable<string> ListOfStrings => _listOfStrings;
        public Form1 TheForm { get; set; }
        public void DoWork(object state)
        {
            var strings = new[] {"Some", "strings", "go", "here"};
            foreach (var s in strings)
            {
                _listOfStrings.Add(s);
                Thread.Sleep(500);
            }
            TheForm?.Invoke(new Action(TheForm.AlertAllDone));
        }
    }
