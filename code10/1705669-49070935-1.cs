    public static List<NumericUpDown> lUpDown = new List<NumericUpDown>();      //List of Updowns we will be using
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level != 0)  //Not adding a NumericUpDown on the Drinks tab
            {
                NumericUpDown newUpDown = new NumericUpDown() { Name = "upDown" + e.Node.Index.ToString() + "_" + e.Node.Parent.Index.ToString() };    //Making a NumericUpDown with a unique name linked to the index of the subnode(Apple juice = 0, Orange Juice = 1, ...) + "_" + index of the node(Drinks, ...) so you can add more subcategories, like food
                Controls.Add(newUpDown);    //Adding to the controls
                newUpDown.BringToFront();   //Bringing to front of the treeview
                lUpDown.Add(newUpDown);     //Adding to our list
            }
            UpdateLocations(e.Node.TreeView);   //Updating location of all NumericUpDowns
        }
        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                foreach (TreeNode subNode in e.Node.Nodes)          //Closing all subnodes which automatically will erase their NumericUpDowns
                {
                    subNode.Collapse();
                }
            }
            else
            {
                NumericUpDown UpDownToRemove = lUpDown.Find(x => x.Name == "upDown" + e.Node.Index.ToString() + "_" + e.Node.Parent.Index.ToString());     //Finding by the index which NumericUpDown we'll remove
                Controls.Remove(UpDownToRemove);    //Removing from Controls
                lUpDown.Remove(UpDownToRemove);     //Removing from our list
                UpdateLocations(e.Node.TreeView);   //Updating location of all NumericUpDowns
            }
        }
        private void UpdateLocations(TreeView tv)
        {
            int index = 0;
            foreach (TreeNode Node in tv.Nodes)     //Going through all nodes in the TreeView(in this case, only Drinks)
            {
                foreach (TreeNode subNode in Node.Nodes)        //Going through all subnodes(childs of Drinks: Apple Juice, Orange Juice, ...)
                {
                    index = subNode.Index;                      //Finding the index of the child
                    if (subNode.IsExpanded)
                    {
                        Point upDownLoc = subNode.FirstNode.Bounds.Location;                                //Geting the location of the Price tag
                        upDownLoc.X += 80;                                                                  //Adding some X points so it goes to the right
                        upDownLoc.Y += subNode.Bounds.Height - 5;                                           //Correcting the height
                        lUpDown.Find(x => x.Name == "upDown" + index.ToString() + "_" + subNode.Parent.Index.ToString()).Location = upDownLoc;      //Finding the correct UpDown to update location by the subnode index(Apple juice = 0, Orange Juice = 1, ...)
                    }
                }
            }
        }
