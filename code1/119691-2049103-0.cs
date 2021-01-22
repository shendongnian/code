    private static void DoIt()
    {
        string x = "blablablamorecontentblablabla?name=michel&score=5&age=28&iliedabouttheage=true";
        string[] arr = x.Split("?".ToCharArray());
        if (arr.Length >= 2)
        {
            string[] arr2 = arr[1].Split("&".ToCharArray());
            foreach (string item in arr2)
            {
                string[] arr3 = item.Split("=".ToCharArray());
                Console.WriteLine("key = " + arr3[0] + " value = " + arr3[1]);
            }
        }
    }
