        private void btnUP_Click(object sender, EventArgs e)
        {
            var tn = tv.SelectedNode;
            if(tn==null) return;
            var idx = tn.Index;
            txt.Text = "Node: " + idx;
            
            var par = tn.Parent;
            if(par==null) return;
            par.Nodes.Remove(tn);
            if (idx > 0)
            {
                par.Nodes.Insert(tn.Index - 1, tn);
                return;
            }
            //if you want to move int its parent's parent [grand parent :) ]
            if (par.Parent!=null)
                par.Parent.Nodes.Add(tn);
        }
