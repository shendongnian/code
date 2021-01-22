    1273 void TreeNode_BeforeCheck(object sender, TreeViewCancelEventArgs e) {
    1274   if (!_treeNodeFirst) {
    1275     _treeNodeFirst = true;
    1276     e.Node.BackColor = Color.Silver;
    1277   }
    1278 }
    1346 void TreeNode_AfterCheck(object sender, TreeViewEventArgs e) {
    1347   if (e.Node.Checked) {
    1348     foreach (TreeNode sub in e.Node.Nodes) {
    1349       sub.Checked = e.Node.Checked;
    1350     }
    1351   }
    1352   if (e.Node.BackColor == Color.Silver) {
    1353     e.Node.BackColor = Color.Empty;
    1354     RunButton.Enabled = IsANodeChecked();
    1355     _treeNodeFirst = false;
    1356   }
    1357 }
    1429 static bool IsANodeChecked(TreeNode node) {
    1430   if (node.Checked) return true;
    1431   foreach (TreeNode sub in node.Nodes) {
    1432     if (IsANodeChecked(sub)) {
    1433       return true;
    1434     }
    1435   }
    1436   return false;
    1437 }
