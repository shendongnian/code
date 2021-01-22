    StringBuilder builder;
    			int nAttr = 5;
    			int size;
    			char ch;
    			Random rnd = new Random();
    			for(int j=0;j<nAttr;j++)
                {
                   builder = new StringBuilder();
                    builder.Append(" ");
    				size=rnd.Next(1,10);
                        for(int k=0; k<size; k++)
                        {
                                ch = Convert.ToChar(Convert.ToInt32(26 * rnd.NextDouble() + 65)) ;
                                if(ch=='[' || ch==']')
                                        j--;
                                else
                                        builder.Append(ch); 
                        }
    				builder.Append("=\"");
    				Console.WriteLine(builder.ToString());
    			}
