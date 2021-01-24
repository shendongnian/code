    public void fishing()
            {
                string numo = "4,-1,5,7,8,10,5,-4,8,10,-30";
                string[] splitted = numo.Split(',');
                int[] nums = new int[splitted.Length];
    
                for (int i = 0; i < splitted.Length; i++)
                {
                    var oneNum = int.Parse(splitted[i]);
                    
                    Debug.WriteLine(oneNum);
                }
            }
