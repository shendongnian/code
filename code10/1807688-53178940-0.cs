    if (item == "Set-Cookie")
    {
        int Start = resp.Headers[item].IndexOf(".ROBLOSECURITY=_", 0);   
        if (Start >= 0)
        {
            Console.WriteLine(resp.Headers[item].IndexOf(".ROBLOSECURITY=_", 0));
            int End = resp.Headers[item].IndexOf("\n domain=", Start);
            Console.WriteLine(resp.Headers[item].Substring(Start, End - Start).Replace(".ROBLOSECURITY=", ""));
            return resp.Headers[item].Substring(Start, End - Start).Replace(".ROBLOSECURITY=", "");
        }
    }
                
