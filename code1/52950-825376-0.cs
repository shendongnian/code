for( int ndx = nodes.Count; ndx > 0; ndx--)
{
  TreeNode node = nodes[ndx-1];
  if (node.Checked)
  {
     nodes.Remove(node);
  }
   // Recurse through the child nodes...
}
