    string sub = "https://www.example.com/site/country/home/products";
            string temp = "";
            string[] ss = sub.Split('/');
            for(int i = 0; i < sub.Length; i++)
            {
                if (ss[i] == "home")
                {
                    i++;
                    for (int j = i; j < ss.Length; j++)
                        temp +='/'+ ss[j];
                    break;
                }
               
            }
            Console.WriteLine(temp);
