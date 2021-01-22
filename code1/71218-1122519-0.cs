    private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
    private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));                 
                builder.Append(ch);
            }
    
            return builder.ToString();
        }
    
    // get 1st random string 
    string Rand1 = RandomString(4);
    
    // get 2nd random string 
    string Rand2 = RandomString(4);
    
    // creat full rand string
    string docNum = Rand1 + "-" + Rand2;
