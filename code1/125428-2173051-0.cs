                                             Thread A           Thread B
                                             --------           --------
if (!UsersOnline.ContainsKey(u.GetUserId())  Statement's true   Statement's true
{
    lock (UsersOnline)                       Get lock           Block
    {
        UsersOnline.Add                      UsersOnline.Add
    }                                        Release Lock
}                                                               Get lock
                                                                UsersOnline.Add
                                                                Release lock   
