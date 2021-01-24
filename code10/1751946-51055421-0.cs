    foreach (Field field in doc.Range.Fields)
    {
        if (field.Type.Equals(Aspose.Words.Fields.FieldType.FieldMergeField))
        {
            Node currentNode = field.Start;
            bool isContinue = true;
            while (currentNode != null && isContinue)
            {
                if (currentNode.NodeType.Equals(NodeType.FieldEnd))
                {
                    FieldEnd end = (FieldEnd)currentNode;
                    if (end == field.End)
                        isContinue = false;
                }
    
                if (currentNode.NodeType.Equals(NodeType.Run))
                {
                    // Specify Font formatting here
                    Run run = ((Run)currentNode);
                    run.Font.Size = 6;
                }
    
                Node nextNode = currentNode.NextPreOrder(currentNode.Document);
                currentNode = nextNode;
            }
        }
    }
