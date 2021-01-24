            int j = 0;
            string a = "foo bar";
            string b = "bar foo";
            char[] array_a = a.ToCharArray();
            char[] array_b = b.ToCharArray();
            for (int i = 0; i < array_b.Count(); i++)
            {
                if(array_b[i] == array_a[j])
                {
                   Console.WriteLine(String.Concat(array_a[j], " : Equal"));
                   j++;
                    //------------------------------Add new------------------------------
                    if (j >= array_a.Count())
                    {
                        while (i < array_b.Count()-1)
                        {
                            Console.WriteLine(String.Concat(array_b[i+1], " : Add"));
                            i++;
                        }
                        goto finish;
                    }
                    //-------------------------------------------------------------------
                }
                else
                {
                    while (array_b[i] != array_a[j])
                    {                        
                        Console.WriteLine(String.Concat(array_a[j], " : Remove"));                       
                        j++;
                        //------------------------------Add new------------------------------
                        if (j >= array_a.Count())
                        {
                           while(i< array_b.Count()-1)
                           {
                                Console.WriteLine(String.Concat(array_b[i+1], " : Add"));
                                i++;                              
                           }
                            goto finish;
                        }
                        //-------------------------------------------------------------------
                    }//end while 
                    Console.WriteLine(String.Concat(array_a[j], " : Equal"));
                    j++;
                    //------------------------------Add new------------------------------
                    if (j >= array_a.Count())
                    {
                        while (i < array_b.Count()-1)
                        {
                            Console.WriteLine(String.Concat(array_b[i+1], " : Add"));
                            i++;
                        }
                        goto finish;
                    }
                    //-------------------------------------------------------------------
                }//end else
            }//end for
            finish:
            MessageBox.Show("Done");
        }
        //OUTPUT CONSOLE:
		/*	
		f : Remove
		o : Remove
		o : Remove
		  : Remove
		b : Equal
		a : Equal
		r : Equal
		  : Add
		f : Add
		o : Add
		o : Add
		*/
