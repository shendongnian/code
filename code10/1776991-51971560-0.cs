            List<string> listWithEmtyAndNullElements = new List<string>
                { "",
                  " ",
                  "Hi",
                  "Stack     ",
                  "    Overflow",
                    null
                };
            List<string> onlyStringList = new List<string>();
            for (int i = 0; i < listWithEmtyAndNullElements.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(listWithEmtyAndNullElements[i]))
                {
                    onlyStringList.Add(listWithEmtyAndNullElements[i]);
                }
             }
