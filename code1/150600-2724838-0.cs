     public static void ProcessNumber(IDnumber myNum)
     {
                        StringBuilder myData = new StringBuilder();
                        myData.AppendLine(myNum.Name);   
                        myData.AppendLine(": ");   
                        myData.AppendLine(myNum.ID);   
                        myData.AppendLine(myNum.year);   
                        myData.AppendLine(myNum.class1);   
                        myData.AppendLine(myNum.class2);   
                        myData.AppendLine(myNum.class3);   
                        myData.AppendLine(myNum.class4);  
                        MessageBox.Show(myData);
     }
