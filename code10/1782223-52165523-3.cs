            int flag = 0;
            int flag_2 = 0;
            string a = "asdfghjk";
            string b = "wsedrftr";
            char[] array_a = a.ToCharArray();
            char[] array_b = b.ToCharArray();
            for (int i = 0,j = 0, n= 0; i < array_b.Count(); i++)
            {   
                //Execute 1 time until reach first equal character   
                if(i == 0 && a.Contains(array_b[0]))
                {
                    while (array_a[n] != array_b[0])
                    {
                        Console.WriteLine(String.Concat(array_a[n], " : Remove"));
                        n++;
                    }
                    Console.WriteLine(String.Concat(array_a[n], " : Equal"));
                    n++;
                }
                else if(i == 0 && !a.Contains(array_b[0]))
                {
                    Console.WriteLine(String.Concat(array_a[n], " : Remove"));
                    n++;
                    Console.WriteLine(String.Concat(array_b[0], " : Add"));
                }
                else
                {
                    if(n < array_a.Count())
                    {
                        if (array_a[n] == array_b[i])
                        {
                            Console.WriteLine(String.Concat(array_a[n], " : Equal"));
                            n++;
                        }
                        else
                        {
                            flag = 0;
                            for (int z = n; z < array_a.Count(); z++)
                            {                              
                                if (array_a[z] == array_b[i])
                                {
                                    flag = 1;
                                    break;
                                }                                                              
                            }
                            if (flag == 0)
                            {
                                flag_2 = 0;
                                for (int aa = i; aa < array_b.Count(); aa++)
                                {
                                    for(int bb = n; bb < array_a.Count(); bb++)
                                    {
                                        if (array_b[aa] == array_a[bb])
                                        {
                                            flag_2 = 1;
                                            break;
                                        }
                                    }
                                }
                                if(flag_2 == 1)
                                {
                                    Console.WriteLine(String.Concat(array_b[i], " : Add"));
                                }
                                else
                                {
                                    for (int z = n; z < array_a.Count(); z++)
                                    {
                                        Console.WriteLine(String.Concat(array_a[z], " : Remove"));
                                        n++;
                                    }
                                     Console.WriteLine(String.Concat(array_b[i], " : Add"));
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine(String.Concat(array_a[n], " : Remove"));
                                i--;
                                n++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(String.Concat(array_b[i], " : Add"));
                    }
                    
                }
                           
            }//end for
        
            MessageBox.Show("Done");
		//OUTPUT CONSOLE:
		/*
		a : Remove
		w : Add
		s : Equal
		e : Add
		d : Equal
		r : Add
		f : Equal
		g : Remove
		h : Remove
		j : Remove
		k : Remove
		t : Add
		r : Add
		*/  
