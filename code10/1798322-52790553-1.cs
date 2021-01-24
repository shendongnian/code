        [Fact]
        public void RemovesAllInstancesOfDuplicateEntries()
        {
            var mylist = new List<MyTable>();
            mylist.Add(new MyTable(1 , "John" , "Miller"));
            mylist.Add(new MyTable(2 , "Jessica", "Scot"));
            mylist.Add(new MyTable(3 , "Robert", "Johnes"));
            mylist.Add(new MyTable(4 , "John", "Miller"));                        
   
            var actual = new MySUT().RemoveAllInstancesOfDuplicates(mylist);
            Assert.Equal(2, actual.Count);
            Assert.Equal(2, actual[0].Id);
            Assert.Equal(3, actual[1].Id);
        }
