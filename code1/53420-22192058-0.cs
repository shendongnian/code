    System.Net.HttpWebRequest request = null;
    System.Net.HttpWebResponse response = null;
    request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("www.example.com/somepath");
    request.Timeout = 30000;
    try
    {
        response = (System.Net.HttpWebResponse)request.GetResponse();
        flag = 1;
    }
    catch 
    {
        flag = -1;
    }
    
    if (flag==1)
    {
        Console.WriteLine("File Found!!!");
    }
    else
    {
        Console.WriteLine("File Not Found!!!");
    }
