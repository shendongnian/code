        public class MyTupleList : List<Tuple<string, string, string>>
        {
            public Tuple<string, string, string> this[string first, string second]
            {
                get
                {
                    return (this.Find(x => x.First == first && x.Second == second));
                }
                set
                {
                    this[first, second] = value;
                }
            }
        }
        [Test]
        public void ShouldFindCorrectTupleInListWhenIndexing()
        {
            MyTupleList list = new MyTupleList();
            list.Add(new Tuple<string, string, string>("test", "test", "test"));
            list.Add(new Tuple<string, string, string>("test", "test2", "wheee"));
            list.Add(new Tuple<string, string, string>("test2", "test2", "test2"));
            var something = list["test", "test"];
            Assert.That(something.Third == "test");
        }  
