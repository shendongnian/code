    char[,,] cube = new char[10, 10, 10];
                    for (int z = 0; z < 10; z++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            for (int x = 0; x < 10; x++)
                            {
                                cube[z, y, x] = (char)(65+x);
                            }
                        }
                    }
    /* Just Filling data in array*/    
                    var s1 = cube.OfType<char>().ToList();
                    string s = string.Join("",s1);
