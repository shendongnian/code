    string inString = @"username: @newbie
    password: 1g1d91dk
    uid: 961515154
    message: blablabla
    date: 30/06/18
    mnumer: 854762158";
    string[] lines = inString.Split('\n');
    Dictionary<string, string> data = new Dictionary<string, string>();
    foreach (string line in lines)
    {
        // There are two ways to avoid splitting multiple : and just using the first
        // Here is my way
        string[] keyValue = line.Split(':');
        data.Add(keyValue[0].Trim(), string.Join(':', keyValue.Skip(1).ToArray()).Trim());
        // Here is another way courtesy of: Dmitry Bychenko
        string[] keyValue = line.Split(new char[] {':'}, 2);
 
        data.Add(keyValue[0].Trim(), keyValue[1].Trim());
    }
