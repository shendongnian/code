        //Method to compare two list
        private bool Contains(IEnumerable<Item> list1, IEnumerable<Item> list2)
        {
            bool result;
            //Get the value
            var list1WithValue = list1.Select(s => s.Value).ToList();
            var list2WithValue = list2.Select(s => s.Value).ToList();
            result = !list1WithValue.Except(list2WithValue).Any();
            
            return result;
        }
