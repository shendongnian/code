    using System;
    public class Program
    {
     public static void Main()
     {
      Console.WriteLine("Employee Salary Prediction for 2020 using Regression Algorithm");
      int[,] xyInputs= new int[,]{{2002,1000},{2003,2000},{2004,3000},{2005,4000},{2006,5000},{2007,6000},{2008,7000}
             ,{2009,8000},{2010,9000},{2011,10000},{2012,11000},{2013,12000},{2015,13000},{2016,14000}
             ,{2017,15000}};
                //consider those values like x and y for the regression formula (y = a + bx;)
      int xValueyValue=0; 
      int xValue=0;
      int yValue=0;
      int xSquareValue=0;
      int lastSalary=0;
       
      for (int i=0;i<xyInputs.Length/2;i++)
      {
       int temp=0;
       for (int j=0;j < xyInputs.Length/2;j++)
          {    
        try{
         
         if(j==0){
           temp =xyInputs[i,j];
               xValue = xValue + temp;
           xSquareValue = xSquareValue + xValue * xValue ;
           }
         if(j==1){
           xValueyValue = xValueyValue + (temp * xyInputs[i,j]);
           yValue = yValue + xyInputs[i,j];
           temp=0;
                 }
         if(i == ((xyInputs.Length/2)-1)){
              lastSalary=(xyInputs[i,j]);
               }
           }catch(Exception ex){
         
           }
        
       }
      }
      //Formula  Sum represents Sumation of  b = (n * Sum(xy) - Sum(x)Sum(y)) / (n * Sum(x^2) - Sum(x)^2). 
         int b =(xyInputs.Length * ((xValueyValue) - (xValue * yValue)))/((xyInputs.Length * xSquareValue)- (xValue * xValue));
      //Formula  Sum represents Sumation of a = (Sum(y)/n)-b(Sum(x)/n)
      int a = (yValue  - (b * xValue))/xyInputs.Length;
      Console.WriteLine("Regression y Value for x = 2020 is :" +(lastSalary + (a + (b * 2020))));
        
     }
    }
