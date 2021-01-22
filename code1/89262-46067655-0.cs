     public void DeleteNode(int nodeIndex)
        {
            int indexCounter = 0;
            Node TempNode = StartNode;
            Node PreviousNode = null;
            while (TempNode.AddressHolder != null)
            {
                if (indexCounter == nodeIndex)
                {
                    PreviousNode.AddressHolder = TempNode.AddressHolder;
                    break;
                }
                indexCounter++;
                PreviousNode = TempNode;
                TempNode = TempNode.AddressHolder;
            }
        }
