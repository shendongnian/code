    Here is one way:
        [Serializable]
        struct card
        {
             public string suit;
             public string value;
        }
        
        [Serializable]
        struct Hand
        {
             public card[] hand;
             public bool[] FinishedCards;
        }
        
        [Serializable]
        struct Message
        {
             public Hand Local, Remote;
             public List<card> Table, Deck;
             public List<card> StackLocal, StackRemote;
        }
    ...
    view.RPC(nameof(RPCAcceptHand),Photon.Pun.RpcTarget.All,JsonUtility.ToJson(m) );
