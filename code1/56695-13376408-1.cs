       arrayRoot = taskData.GetRocordForRoot();  // iterate through database table
        for (int j = 0; j <arrayRoot.length; j++) { 
                    TreeNode root = new TreeNode();  // Creating new root node
                    root.Text = "displayString";
                    root.Tag = "valueString";
                    treeView1.Nodes.Add(root); //Adding the root node
    
                 arrayChild = taskData.GetRocordForChild();// iterate through database table
                    for (int i = 0; i < arrayChild.length; i++) {
                        TreeNode child = new TreeNode(); // creating child node
                        child.Text = "displayString"
                        child.Tag = "valueString";
                        root.Nodes.Add(child); // adding child node
                    }
    
                }
