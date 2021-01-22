        [TestMethod]
        public void TestSearch()
        {
            List<string> tasks = new List<string>
                {
                    "Add contract to Customer.",
                    "New contract for customer.",
                    "Create new contract.",
                    "Go through the old contracts.",
                    "Attach files to customers."
                };
            var filteredTasks = SearchListWithSearchPhrase(tasks, "contract customer new");
            filteredTasks.ForEach(Console.WriteLine);
        }
        public static List<string> SearchListWithSearchPhrase(List<string> tasks, string searchPhrase)
        {
            var query = tasks.AsEnumerable();
            foreach (var term in searchPhrase.Split(new[] { ' ' }))
            {
                string s = term.Trim();
                query = query.Where(x => x.IndexOf(s, StringComparison.InvariantCultureIgnoreCase) != -1);
            }
            return query.ToList();
        }
