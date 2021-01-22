    void CloneTree() 
    {
                //save the current tree into stream
                var savedTree = new MemoryStream();
                ultraTree1.SaveAsBinary(savedTree);
                byte[] buffer = savedTree.ToArray();
                savedTree.Close()
    
                //create a clone from the stream
                UltraTree newTree = new UltraTree();
                newTree.LoadFromBinary(new MemoryStream(buffer));
    }
