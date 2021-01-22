    List <string>  list= new List<string>("Box", "Gate", "Car");
    string SearchStr ="Box";
        int BoxId= 0;
            foreach (string SearchString in list)
            {
                if (str == SearchString)
                {
                    BoxId= list.IndexOf(str);
                    break;
                }
            }
