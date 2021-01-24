            var testArray = new string[] { "??", "??", "FF", "5B", "??", "01", "??" };
            List<String> list = testArray.ToList();
            //Remove "??" from starting
            for (int i=0;i< list.Count;i++)
            {
                if(list[0]!= "??")
                {
                    break;
                }
                list.RemoveAt(0);
            }
            //Remove "??" from ending
            for (int i = list.Count; i > 0; i--)
            {
                if (list[list.Count-1] != "??")
                {
                    break;
                }
                list.RemoveAt(list.Count-1);
            }
