    internal void sendmsg(string v)
    {
        NetOutgoingMessage outmsg = tclient.CreateMessage();
        outmsg.Write((byte)DataType.DATATYPEMSG);
        outmsg.Write(v);
        tclient.SendMessage(outmsg, NetDeliveryMethod.ReliableUnordered);
    }
