    public void SplitExample()
    {
    List<string> Lines = new List<string>()
            {
                "[20:03:01 INFO]: UUID of player MyUsername123 is b87e1cbc-c67c-4026-a359-8659de8b4",
                "[21:03:10 INFO]: UUID of player Cool_Username is b7ecbc-c67c-4026-a359-8652f9de8b4",
                "[22:23:10 INFO]: UUID of player theuserN4m3 is b87eabc-c67c-4026-a359-8652ad9dssdse8b4",
                "[20:08:10 INFO]: UUID of player WhatANiceUsername is b87g1cbc-c67c-4026-a359-8652agde8b4",
            };
    foreach(var i in Lines)
    {
        var splitArray = i.Split(' ');
        Console.WriteLine(splitArray[5]);
    }
}
