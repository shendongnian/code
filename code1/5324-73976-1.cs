    class MyFixedTable
    {      int MyNum {get; set;}
           int YourNum {get; set;}
           string OneChar {get; set;}
       public MyFixedTable(MyTable t)
       {
             this,MyNum = t.MyNum;
             this.YourNum = t.YourNum;
             this.OneChar = new string(t.OneChar, 1);
       }
    }
