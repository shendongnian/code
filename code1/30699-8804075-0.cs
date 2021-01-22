    Console.WriteLine("The value 99999 in various Format");
    String s = "$";
    String s1=s.Replace(s,"RS");
    String s2 = String.Format("{0:c}", s1);
    String s3="1000";
    Console.WriteLine(s2 + s3);
