    bool ConnectionExists()
    {
    try
    {
    System.Net.Sockets.TcpClient clnt=new System.Net.Sockets.TcpClient("www.google.com",80);
    clnt.Close();
    return true;
    }
    catch(System.Exception ex)
    {
    return false;
}
}
