    public class MyModel
    {
        static set<int> send_msg1 = set<int>.EmptySet; // has server #n sent msg #1?
        static set<int> recv_msg1 = set<int>.EmptySet; // has server #n received msg #1?
        // (etc for more messages)
        static int X = 1;
        static int Y = 2;
        // (etc for more server names)
        [Action]
        static void YSendMsg1()
        {
           // Y sends Msg1 to Z
           send_msg1 = send_msg1.Add(Y);
           recv_msg1 = recv_msg1.Add(Z);
        }
        static bool YSendMsg1Enabled()
        {
           // in the simplest case, this can happen whenever Y has received the
           // message but not yet forwarded it
           return recv_msg1.Contains(Y) && !send_msg1.Contains(Y);
        }
    }
