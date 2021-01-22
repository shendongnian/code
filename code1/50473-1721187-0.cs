    void CloneTree() 
    {
                //save the current tree into stream
                var savedTree = new MemoryStream();
                ultraTree1.SaveAsBinary(savedTree);
    
                //create a clone from the stream
                UltraTree newTree = new UltraTree();
                newTree.LoadFromBinary(savedTree);
    }
