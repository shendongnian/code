    public class Distinct
    {
        private string input = "STA27,STA27,STA27B,STA27A,STA27B,";
        [Test]
        public void DistinctTest()
        {
            var distincts = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
            foreach(var entry in distincts)
            {
                Console.WriteLine(entry);
            }
        }
    }
