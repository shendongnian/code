        public string[] RemoveDuplicates(string[] myList) {
            System.Collections.ArrayList newList = new System.Collections.ArrayList();
            foreach (string str in myList)
                if (!newList.Contains(str))
                    newList.Add(str);
            return (string[])newList.ToArray(typeof(string));
        }
