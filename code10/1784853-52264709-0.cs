     Console.WriteLine("Please Enter Your DateTime: \n");
                //you input your string dateTime Like 2/12/2013
    
                string DateInput = Console.ReadLine();
    
                //split it
                string[] DateTimeArray = DateInput.Split('/');
    
                //String DateTime 
                string ResultStringDateTime="";
    
                //this loop is for create string DateTime with Type Like 2-12-2013
                for (int i = 0; i < DateTimeArray.Length; i++)
                {
                    if (i==2)
                    {
                        ResultStringDateTime += DateTimeArray[i];
                        continue;
                    }
                    ResultStringDateTime += DateTimeArray[i]+"-";
                }
    
                //if u want change you must change in this line 
    
                //this is DateTime Type Of your DateTime 
                DateTime myDate;
    
                //in this step if you have error this will be message else create date time 
                try
                {
    
                    //out String DateTime
                    myDate = Convert.ToDateTime(ResultStringDateTime);
                    Console.WriteLine(myDate.ToShortDateString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("err "+e.Message );
                }
    
                Console.ReadLine();
