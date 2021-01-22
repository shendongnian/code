            public class AA
            {
                public string name;
            }
            public class BB : AA 
            {
                public BB(AA aa)
                {
                    name = aa.name;
                }
            }
